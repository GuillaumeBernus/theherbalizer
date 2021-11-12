using System;
using System.Runtime.Serialization;

namespace MowerEngine.Exceptions
{
    [Serializable]
    public class InvalidRouteDescriptionException : Exception
    {
        public InvalidRouteDescriptionException()
        {
        }

        public InvalidRouteDescriptionException(string message) : base(message)
        {
        }

        public InvalidRouteDescriptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRouteDescriptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}