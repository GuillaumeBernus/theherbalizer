using System;

namespace MowerEngine.Models
{
    public class Point : ICloneable
    {
        public int X { get; set; }

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
