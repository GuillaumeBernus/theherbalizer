using System.ComponentModel.DataAnnotations;

namespace Lawn.API.Models
{
    /// <summary>
    /// Class PointViewModel.
    /// Implements the <see cref="System.IEquatable{Lawn.API.Models.PointViewModel}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{Lawn.API.Models.PointViewModel}" />
    public record PointViewModel
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