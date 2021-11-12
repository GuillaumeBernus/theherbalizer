using System.Collections.Generic;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class Lawn.
    /// </summary>
    public class Lawn
    {
        /// <summary>
        /// Gets or sets the upper rigth corner.
        /// </summary>
        /// <value>The upper rigth corner.</value>
        public Point UpperRigthCorner { get; set; }
        /// <summary>
        /// Gets or sets the mowers.
        /// </summary>
        /// <value>The mowers.</value>
        public List<Mower> Mowers { get; set; }

        /// <summary>
        /// Froms the lawn description.
        /// </summary>
        /// <param name="lawnDescription">The lawn description.</param>
        /// <returns>Lawn.</returns>
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