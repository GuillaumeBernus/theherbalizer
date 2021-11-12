namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class Mower.
    /// </summary>
    public record Mower
    {
        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>The start position.</value>
        public MowerPosition StartPosition { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        public string Route { get; set; }

    }
}