using LawnFile.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LawnFile.Domain.Model
{
    public static class MowerParser
    {
        /// <summary>
        /// Froms the mower description.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="route">The route.</param>
        /// <returns>Mower.</returns>
        /// <exception cref="System.Exception">Wrong mower start position description</exception>
        /// <exception cref="System.Exception">Wrong route description</exception>
        public static Mower Parse(string position, string route)
        {
            if (!MowerPositionParser.TryParse(position, out MowerPosition startPosition))
            {
                throw new InvalidPositionDescriptionException();
            }

            if (!route.IsMowerRoute())
            {
                throw new InvalidRouteDescriptionException();
            }

            return new Mower
            {
                StartPosition = startPosition,
                Route = route
            };
        }
    }
}