using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class MowerPosition.
    /// Implements the <see cref="System.IEquatable{MowerEngine.Models.MowerPosition}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{MowerEngine.Models.MowerPosition}" />
    public record MowerPosition
    {
        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        [Required]
        public Point Coordinates { get; set; }
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Required]
        public Direction Orientation { get; set; }

    }
}