using System.ComponentModel.DataAnnotations;

namespace Lawn.API.Models
{
    /// <summary>
    /// Class MowerPosition.
    /// Implements the <see cref="System.IEquatable{MowerEngine.Models.MowerPosition}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{MowerEngine.Models.MowerPosition}" />
    public record MowerPositionViewModel
    {
        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        [Required]
        public PointViewModel Coordinates { get; set; }
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Required]
        public string Orientation { get; set; }
    }
}