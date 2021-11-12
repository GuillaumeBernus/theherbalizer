using System;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class MowerPositionParser.
    /// </summary>
    public static class MowerPositionParser
    {

        /// <summary>
        /// Tries to parse a string into a <c>MowerPosition</c>.
        /// </summary>
        /// <param name="startPosition">The start position.</param>
        /// <param name="mowerPosition">The mower position.</param>
        /// <returns><c>true</c> if parse succeeds, <c>false</c> otherwise.</returns>
        public static bool TryParse(string startPosition, out MowerPosition mowerPosition)
        {
            mowerPosition = null;

            var members = startPosition.Split(" ");

            if (members.Length != Constants.PositionDescriptionMembersCount)
            {
                return false;
            }

            var pointDescription = $"{members[0]} {members[1]}";

            if (!PointParser.TryParse(pointDescription, out Point position)
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