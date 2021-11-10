using System;
using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    public class Point : ICloneable
    {

        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }

        public object Clone()
        {
            return new Point { X = this.X, Y = this.Y };
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
