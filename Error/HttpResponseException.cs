using System;
using System.Net;
using record_keep_api.Models.Error;

namespace record_keep_api.Error
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(object errorObject = null,
            HttpStatusCode status = HttpStatusCode.InternalServerError)
        {
            Status = status;
            Value = new ErrorValue
            {
                Status = (int) status,
                Errors = errorObject
            };
        }

        public HttpStatusCode Status { get; set; }

        public ErrorValue Value { get; set; }
    }
}