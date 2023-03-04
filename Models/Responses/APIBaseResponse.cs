using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AtechAPI.Models.Responses
{
    public class APIBaseResponse<T>
    {
        public APIBaseResponse()
        {
            StatusCode = (int)HttpStatusCode.OK;
            ErrorList = new List<string>();
        }
        public T Data { get; set; }
        public string SuccessMessage { get; set; }
        public int? ReferenceNumber { get; set; }

        public int StatusCode { get; set; }
        public List<string> ErrorList { get; set; }

        public bool IsSuccess { get; set; } = true;
        public int? TotalRecords { get; set; }
        public object ValidationErrorList { get; set; }

        public JsonResult GetHttpErrorResponse(HttpStatusCode errorType, string msg)
        {
            // Added the status-code properly without changing the previous response model of the API
            this.ErrorList.Add(msg);
            this.StatusCode = (int)errorType;
            this.IsSuccess = false;


            return new JsonResult(this)
            {
                StatusCode = (int)errorType

                // The APP does not have necessary code to handle not-200 HTTP responses
                // Hence, making all the responses to have 200 status even though these were caused by some erroneous requests
                //  StatusCode = (int)ErrorType.Ok
            };
        }

        public JsonResult GetHttpErrorResponse(HttpStatusCode errorType)
        {
            // Added the status-code properly without changing the previous response model of the API
            this.StatusCode = (int)errorType;
            return new JsonResult(this)
            {
                StatusCode = (int)errorType

                // The APP does not have necessary code to handle not-200 HTTP responses
                // Hence, making all the responses to have 200 status even though these were caused by some erroneous requests
                // StatusCode = (int)ErrorType.Ok
            };
        }
        public JsonResult GetHttpResponse(HttpStatusCode statusCode)
        {
            // Added the status-code properly without changing the previous response model of the API
            this.StatusCode = (int)statusCode;
            this.IsSuccess = ((int)statusCode == 200) ? true : false;
            return new JsonResult(this)
            {
                StatusCode = (int)statusCode

                
            };
        }

        
    }
}
