using System;
using System.Net;
using System.Runtime.Serialization;

namespace LawnFile.Infrastructure.Exceptions
{
    /// <summary>
    /// Class LawnApiException.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class LawnApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiException"/> class.
        /// </summary>
        public LawnApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public LawnApiException(HttpStatusCode? statusCode) : base(statusCode.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LawnApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public LawnApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected LawnApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}