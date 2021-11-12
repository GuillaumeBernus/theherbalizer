using System;
using System.Runtime.Serialization;

namespace MowerEngine.Models.Exceptions
{
    /// <summary>
    /// Class InvalidMowerException.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class InvalidMowerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMowerException"/> class.
        /// </summary>
        public InvalidMowerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMowerException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidMowerException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMowerException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public InvalidMowerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMowerException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected InvalidMowerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}