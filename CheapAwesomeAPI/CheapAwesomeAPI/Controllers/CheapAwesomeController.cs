using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheapAwesome.API.Infrastructure.Filters;
using CheapAwesome.Domain.Models.Request;
using CheapAwesome.Domain.Models.Response;
using CheapAwesomeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CheapAwesomeAPI.Controllers
{
    [ApiVersion("1.0")]
    public class CheapAwesomeController : BaseController
    {
        private readonly ILogger<CheapAwesomeController> _logger;
        private readonly ISupplierHotelService _service;

        public CheapAwesomeController(ILogger<CheapAwesomeController> logger,ISupplierHotelService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels([FromQuery]int destId,[FromQuery]int noOfNights )
        {
            if (destId == 0)
                return BadRequest() as IActionResult;

            _logger.LogInformation($"{nameof(CheapAwesomeController)} - {nameof(GetHotels)} - called");
            var response= await _service.GetHotelList(new GetHotelRequest() { destId = destId, noOfNights = noOfNights });
            return response != null ? Ok(CommonResponse.CreateSuccessResponse("Success",response)) : BadRequest() as IActionResult;
        }
    }
}