using System;
using System.Runtime.Serialization;

namespace MowerEngine.Models.MoveHandler
{
    [Serializable]
    public class NullMoveException : Exception
    {
        public NullMoveException()
        {
        }

        public NullMoveException(string message) : base(message)
        {
        }

        public NullMoveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullMoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}