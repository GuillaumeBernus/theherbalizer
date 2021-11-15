using System.ComponentModel.DataAnnotations;

namespace Lawn.API.Models
{
    /// <summary>
    /// Class MowerPositionViewModel.
    /// Implements the MowerPositionViewModel
    /// </summary>
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