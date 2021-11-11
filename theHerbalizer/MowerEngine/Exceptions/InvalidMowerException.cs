using System;
using System.Runtime.Serialization;

namespace MowerEngine.Models.Exceptions
{
    [Serializable]
    public class InvalidMowerException : Exception
    {
        public InvalidMowerException()
        {
        }

        public InvalidMowerException(string message) : base(message)
        {
        }

        public InvalidMowerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMowerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}