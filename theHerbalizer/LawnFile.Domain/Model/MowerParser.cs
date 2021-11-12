using LawnFile.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LawnFile.Domain.Model
{
    public static class MowerParser
    { 
        /// <summary>
        /// Froms the mower description list.
        /// </summary>
        /// <param name="mowerDescriptions">The mower descriptions.</param>
        /// <returns>List&lt;Mower&gt;.</returns>
        internal static List<Mower> FromMowerDescriptionList(IEnumerable<MowerDescription> mowerDescriptions)
        {
            return mowerDescriptions.Select(FromMowerDescription).ToList();
        }

        /// <summary>
        /// Froms the mower description.
        /// </summary>
        /// <param name="mowerDescription">The mower description.</param>
        /// <returns>Mower.</returns>
        /// <exception cref="System.Exception">Wrong mower start position description</exception>
        /// <exception cref="System.Exception">Wrong route description</exception>
        private static Mower FromMowerDescription(MowerDescription mowerDescription)
        {
            if (!MowerPositionParser.TryParse(mowerDescription.StartPosition, out MowerPosition startPosition))
            {
                throw new Exception("Wrong mower start position description");
            }

            if (!mowerDescription.Route.IsMowerRoute())
            {
                throw new Exception("Wrong route description");
            }

            return new Mower
            {
                StartPosition = startPosition,
                Route = mowerDescription.Route
            };
        }

    }
}