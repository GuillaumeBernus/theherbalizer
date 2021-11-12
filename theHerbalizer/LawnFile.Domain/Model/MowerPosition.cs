using System;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class MowerPosition.
    /// </summary>
    public class MowerPosition
    {
        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        public Point Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Direction Orientation { get; set; }

        /// <summary>
        /// Tries to parse a string into a <c>MowerPosition</c>.
        /// </summary>
        /// <param name="startPosition">The start position.</param>
        /// <param name="mowerPosition">The mower position.</param>
        /// <returns><c>true</c> if parse succeeds, <c>false</c> otherwise.</returns>
        internal static bool TryParse(string startPosition, out MowerPosition mowerPosition)
        {
            mowerPosition = null;

            var members = startPosition.Split(" ");

            if (members.Length != 3)
            {
                return false;
            }

            var pointDescription = $"{members[0]} {members[1]}";

            if (!Point.TryParse(pointDescription, out Point position)
                || !Enum.TryParse<Direction>(members[2], out Direction orientation))
            {
                return false;
            }

            mowerPosition = new MowerPosition
            {
                Coordinates = position,
                Orientation = orientation
            };
            return true;
        }
    }
}