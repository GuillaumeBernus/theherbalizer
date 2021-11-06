using System;

namespace LawnFile.Domain.Model
{
    public class MowerPosition
    {
        public Point Position { get; set; }

        public Direction Orientation { get; set; }

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

            mowerPosition= new MowerPosition
            {
                Position = position,
                Orientation = orientation
            };
            return true;
        }
    }
}