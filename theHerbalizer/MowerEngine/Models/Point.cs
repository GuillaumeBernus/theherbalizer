using System;
using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class Point.
    /// Implements the <see cref="System.ICloneable" />
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    public class Point : ICloneable
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

        public object Clone()
        {
            return new Point
            {
                X = this.X,
                Y = this.Y
            };
        }
    }
}