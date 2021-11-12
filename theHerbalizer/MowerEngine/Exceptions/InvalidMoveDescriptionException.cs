using System;
using System.Runtime.Serialization;

namespace MowerEngine.Models.Exceptions
{
    [Serializable]
    public class InvalidMoveDescriptionException : Exception
    {
        public InvalidMoveDescriptionException()
        {
        }

        public InvalidMoveDescriptionException(string message) : base(message)
        {
        }

        public InvalidMoveDescriptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMoveDescriptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}