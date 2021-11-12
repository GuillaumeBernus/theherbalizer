using System;
using System.Runtime.Serialization;

namespace MowerEngine.Models.Exceptions
{
    [Serializable]
    public class InvalidValueForFrontMoveException : Exception
    {
        public InvalidValueForFrontMoveException()
        {
        }

        public InvalidValueForFrontMoveException(string message) : base(message)
        {
        }

        public InvalidValueForFrontMoveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidValueForFrontMoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}