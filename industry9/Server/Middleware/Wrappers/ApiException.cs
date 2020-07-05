using System;
using System.Collections.Generic;

namespace industry9.Server.Middleware.Wrappers
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public bool IsModelValidationError { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }

        public ApiException(string message,
            int statusCode = 500,
            string errorCode = "",
            string refLink = "") :
            base(message)
        {
            IsModelValidationError = false;
            StatusCode = statusCode;
            ReferenceErrorCode = errorCode;
            ReferenceDocumentLink = refLink;
        }

        public ApiException(IEnumerable<ValidationError> errors, int statusCode = 400)
        {
            IsModelValidationError = true;
            StatusCode = statusCode;
            Errors = errors;
        }

        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            IsModelValidationError = false;
            StatusCode = statusCode;
        }
    }
}
