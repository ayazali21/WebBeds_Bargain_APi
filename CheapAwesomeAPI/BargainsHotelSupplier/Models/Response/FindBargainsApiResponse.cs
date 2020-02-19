using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BargainHotelSupplier.Models.BargainSupplierModel.Response
{
    public  class FindBargainsApiResponse
    {
        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }

        [JsonProperty("rates")]
        public List<Rate> Rates { get; set; }
    }

    public  class Hotel
    {
        [JsonProperty("propertyID")]
        public int PropertyId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("geoId")]
        public long GeoId { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }

    public  class Rate
    {
        [JsonProperty("rateType")]
        public RateType RateType { get; set; }

        [JsonProperty("boardType")]
        public string BoardType { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }


    public enum RateType { PerNight, Stay };

}
