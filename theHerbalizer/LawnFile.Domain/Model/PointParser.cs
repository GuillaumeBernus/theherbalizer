using System;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class PointParser.
    /// </summary>
    public static class PointParser
    {

        /// <summary>
        /// Froms the point description.
        /// </summary>
        /// <param name="pointDescription">The point description.</param>
        /// <returns>Point.</returns>
        /// <exception cref="System.Exception">Wrong point description</exception>
        internal static Point Parse(string pointDescription)
        {
            if (!TryParse(pointDescription, out Point point))
            {
                throw new Exception("Wrong point description");
            }

            return point;
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="pointDescription">The point description.</param>
        /// <param name="point">The point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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