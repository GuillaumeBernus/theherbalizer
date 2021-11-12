using System;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class Point.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>The x.</value>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>The y.</value>
        public int Y { get; set; }

        /// <summary>
        /// Froms the point description.
        /// </summary>
        /// <param name="pointDescription">The point description.</param>
        /// <returns>Point.</returns>
        /// <exception cref="System.Exception">Wrong point description</exception>
        internal static Point FromPointDescription(string pointDescription)
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