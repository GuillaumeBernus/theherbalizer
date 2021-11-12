using System;
using System.Runtime.Serialization;

namespace MowerEngine.Models.Exceptions
{
    [Serializable]
    public class WrongMoveTypeException : Exception
    {
        public WrongMoveTypeException()
        {
        }

        public WrongMoveTypeException(string message) : base(message)
        {
        }

        public WrongMoveTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongMoveTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}