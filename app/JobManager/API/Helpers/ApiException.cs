using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JobManager.API.Helpers
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }

        public ApiException(HttpStatusCode statusCode,string message, Exception innerException) : base(message, innerException)
        {

        }
    }
      
}
