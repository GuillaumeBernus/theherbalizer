using System;

namespace LawnFile.Domain.Model
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        internal static Point FromPointDescription(string pointDescription)
        {
            if (!TryParse(pointDescription, out Point point))
            {
                throw new Exception("Wrong point description");
            }

            return point;
        }

        internal static bool TryParse(string pointDescription, out Point point)
        {
            var coords = pointDescription.Split(" ");
            if (coords.Length != 2 || !int.TryParse(coords[0], out int x) || !int.TryParse(coords[1], out int y))
            {
                point = null;
                return false;
            }
            point = new Point { X = x, Y = y };
            return true;
        }
    }
}