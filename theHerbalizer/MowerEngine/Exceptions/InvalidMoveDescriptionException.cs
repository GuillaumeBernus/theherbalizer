using System;
using System.Runtime.Serialization;

namespace MowerEngine.Exceptions
{
    /// <summary>
    /// Class InvalidMoveDescriptionException.
    /// Implements the <see cref="Exception" />
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public class InvalidMoveDescriptionException : InvalidDescriptionException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMoveDescriptionException"/> class.
        /// </summary>
        public InvalidMoveDescriptionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMoveDescriptionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidMoveDescriptionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMoveDescriptionException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public InvalidMoveDescriptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMoveDescriptionException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected InvalidMoveDescriptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}