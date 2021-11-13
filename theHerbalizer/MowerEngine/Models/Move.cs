namespace MowerEngine.Models
{
    /// <summary>
    /// Class Move.
    /// Implements the <see cref="System.IEquatable{MowerEngine.Models.Move}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{MowerEngine.Models.Move}" />
    public record Move
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public MoveType Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class.
        /// </summary>
        public Move()
        {
        }
    }
}