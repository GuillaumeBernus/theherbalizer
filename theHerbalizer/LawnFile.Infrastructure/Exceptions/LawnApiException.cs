using System;
using System.Net;
using System.Runtime.Serialization;

namespace LawnFile.Infrastructure.Exceptions
{
    [Serializable]
    public class LawnApiException : Exception
    {
        private HttpStatusCode? statusCode;

        public LawnApiException()
        {
        }

        public LawnApiException(HttpStatusCode? statusCode) : base(statusCode.ToString())
        {
        }

        public LawnApiException(string message) : base(message)
        {
        }

        public LawnApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LawnApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}