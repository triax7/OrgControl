using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OrgControlServer.BLL.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; init; }

        public AppException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
