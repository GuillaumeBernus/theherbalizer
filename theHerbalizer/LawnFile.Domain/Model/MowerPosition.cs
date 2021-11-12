using System;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class MowerPosition.
    /// </summary>
    public record MowerPosition
    {
        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        public Point Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Direction Orientation { get; set; }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{Coordinates?.ToString() ?? String.Empty} {Orientation}";
        }


    }
}