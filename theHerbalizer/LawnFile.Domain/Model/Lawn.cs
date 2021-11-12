using System.Collections.Generic;

namespace LawnFile.Domain.Model
{
    public class Lawn
    {
        public Point UpperRigthCorner { get; set; }
        public List<Mower> Mowers { get; set; }

        internal static Lawn FromLawnDescription(LawnDescription lawnDescription)
        {
            return new Lawn
            {
                UpperRigthCorner = Point.FromPointDescription(lawnDescription.UpperRightCorner),
                Mowers = Mower.FromMowerDescriptionList(lawnDescription.MowerDescriptions)
            };
        }
    }
}