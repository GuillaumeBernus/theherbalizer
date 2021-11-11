using System;
using System.Runtime.Serialization;

namespace MowerEngine.Exceptions
{
    [Serializable]
    public class InvalidLawnException : Exception
    {
        public InvalidLawnException()
        {
        }

        public InvalidLawnException(string message) : base(message)
        {
        }

        public InvalidLawnException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLawnException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}