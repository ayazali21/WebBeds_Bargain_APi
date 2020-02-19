using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CheapAwesome.Domain.Models.Response
{
    public class CommonResponse
    {
        public CommonResponse()
        {

        }

        /// <summary>
        /// Assign the common response values
        /// </summary>
        /// <param name="message"></param>
        /// <param name="successful"></param>

        public CommonResponse(string message, bool successful, object data = null)
        {
            this.Message = message;
            this.Successful = successful;
            this.Data = data;
        }

        /// <summary>
        /// Assign the common response values
        /// </summary>
        /// <param name="message"></param>
        /// <param name="successful"></param>
        /// <param name="total"></param>
        /// <param name="data"></param>
        public CommonResponse(string message, bool successful, int? total, object data = null)
        {
            this.Message = message;
            this.Successful = successful;
            this.Data = data;
            this.Total = total;
        }

        /// <summary>
        /// Assign the common response values
        /// </summary>
        /// <param name="message"></param>
        /// <param name="successful"></param>
        /// <param name="details"></param>
        public CommonResponse(string message, bool successful, string details)
        {
            this.Message = message;
            this.Successful = successful;
            this.Details = details;
        }

        /// <summary>
        /// Assign the common response values
        /// </summary>
        /// <param name="modelState"></param>
        public CommonResponse(ModelStateDictionary modelState)
        {

            this.Successful = false;
            this.Message = "Validation Failed";
            this.Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }

        /// <summary>
        /// List of model validation errors 
        /// </summary>
        [JsonProperty("Errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidationError> Errors { get; set; }

        /// <summary>
        /// Details for the error triggered
        /// </summary>

        [JsonProperty("Details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }

        /// <summary>
        /// Status of the request
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Message to be returned from the API
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// will contain the response data to be returned by api call
        /// </summary>
        [JsonProperty("Data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        [JsonProperty("Total", NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }

        /// <summary>
        /// Factory method to create success response
        /// </summary>
        /// <param name="message"></param>
        /// <returns>CommonResponse</returns>
        public static CommonResponse CreateSuccessResponse(string message = "", object data = null) => new CommonResponse(message, true, data);

        /// <summary>
        /// Factory method to create paging success response
        /// </summary>
        /// <param name="message"></param>
        /// <param name="total"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static CommonResponse CreatePaginationResponse(string message = "", int? total = null, object data = null) => new CommonResponse(message, true, total, data);

        /// <summary>
        /// Factory method to create success with details response
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <returns>CommonResponse</returns>
        public static CommonResponse CreateSuccessWithDetailsResponse(string message = "", string details = "")
            => new CommonResponse(message, true, details);

        /// <summary>
        /// Factory method to create success failure response
        /// </summary>
        /// <param name="message"></param>
        /// <returns>CommonResponse</returns>
        public static CommonResponse CreateFailedResponse(string message = "") => new CommonResponse(message, false);

        /// <summary>
        /// Factory method to create error response and populate with errors from model state
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns>CommonResponse</returns>
        public static CommonResponse CreateErrorResponse(ModelStateDictionary modelState) => new CommonResponse(modelState);
    }

}
