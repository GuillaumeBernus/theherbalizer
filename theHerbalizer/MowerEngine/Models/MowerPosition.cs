using System;
using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class MowerPosition.
    /// Implements the <see cref="System.ICloneable" />
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    public class MowerPosition : ICloneable
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

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return new MowerPosition
            {
                Coordinates = this.Coordinates.Clone() as Point,
                Orientation = this.Orientation
            };
        }
    }
}