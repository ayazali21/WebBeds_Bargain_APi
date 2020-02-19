using BargainHotelSupplier.Models.BargainSupplierModel.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BargainHotelSupplier
{
    public class BargainHotelSupplierClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL;
        private readonly string _key;
        public BargainHotelSupplierClient(string baseUrl, string key)
        {
            _httpClient = new HttpClient();
            _baseURL = baseUrl;
            _key = key;
        }

        public async Task<List<FindBargainsApiResponse>> findBargain(int destId, int noOfNights)
        {
            var response = await _httpClient.GetAsync($"{_baseURL}/findBargain?destinationId={destId}&nights={noOfNights}&code={_key}");

             var res =await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FindBargainsApiResponse>>(res);

        }

    }
}
