using LawnFile.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class Mower.
    /// </summary>
    public class Mower
    {
        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>The start position.</value>
        public MowerPosition StartPosition { get; set; }

        //public IEnumerable<MowerAction> Route { get; set; }
        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        public string Route { get; set; }

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
            if (!MowerPosition.TryParse(mowerDescription.StartPosition, out MowerPosition startPosition))
            {
                throw new Exception("Wrong mower start position description");
            }

            //if (!TryParseRoute(mowerDescription.Route, out IEnumerable<MowerAction> route))
            //{
            //    throw new Exception("Wrong route description");
            //}

            if (!mowerDescription.Route.IsMowerRoute())
            {
                throw new Exception("Wrong route description");
            }

            return new Mower
            {
                StartPosition = startPosition,
                Route = mowerDescription.Route//route
            };
        }

        /// <summary>
        /// Tries the parse route.
        /// </summary>
        /// <param name="routeDescription">The route description.</param>
        /// <param name="route">The route.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool TryParseRoute(string routeDescription, out IEnumerable<MowerAction> route)
        {
            var actionDescriptions = routeDescription.ToCharArray();

            var actionList = new List<MowerAction>(actionDescriptions.Length);

            foreach (var item in actionDescriptions)
            {
                if (!Enum.TryParse<MowerAction>(item.ToString(), out MowerAction action))
                {
                    route = null;
                    return false;
                }
                actionList.Add(action);
            }
            route = actionList;
            return true;
        }
    }
}