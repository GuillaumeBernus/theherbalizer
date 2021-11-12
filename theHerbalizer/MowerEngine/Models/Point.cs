using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class Point.
    /// Implements the <see cref="System.IEquatable{MowerEngine.Models.Point}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{MowerEngine.Models.Point}" />
    public record Point
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>The x.</value>
        [Required]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>The y.</value>
        [Required]
        public int Y { get; set; }

    }
}