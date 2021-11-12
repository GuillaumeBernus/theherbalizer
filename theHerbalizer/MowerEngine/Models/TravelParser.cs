using MowerEngine.Exceptions;
using System.Collections.Generic;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class TravelParser.
    /// </summary>
    public static class TravelParser
    {
        /// <summary>
        /// Parses the specified route description.
        /// </summary>
        /// <param name="routeDescription">The route description.</param>
        /// <returns>List&lt;Move&gt;.</returns>
        public static List<Move> Parse(string routeDescription)
        {
            var stringMoves = SplitRoute(routeDescription);
            var travel = new List<Move>();
            stringMoves.ForEach(m => travel.Add(MoveParser.Parse(m)));
            return travel;
        }

        /// <summary>
        /// Splits the route.
        /// </summary>
        /// <param name="stringRoute">The string route.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <exception cref="MowerEngine.Exceptions.InvalidRouteDescriptionException"></exception>
        private static List<string> SplitRoute(string stringRoute)
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(stringRoute) || !stringRoute.IsTravelDescription())
            {
                throw new InvalidRouteDescriptionException();
            }

            int start = 0, index = -1;

            var delimitors = new Dictionary<bool, char[]>(){
                { false, new char[]{ Constants.FrontMoveCharacter } },
                { true, new char[] { Constants.RightRotationCharacter, Constants.LeftRotationCharacter } }
                };

            var isCurrentMoveAFrontMove = stringRoute[0] == Constants.FrontMoveCharacter;

            while ((index = stringRoute.IndexOfAny(delimitors[isCurrentMoveAFrontMove], start)) != -1)
            {
                if (index - start > 0)
                    result.Add(stringRoute.Substring(start, index - start));
                else
                    result.Add(stringRoute.Substring(index, 1));
                start = index;
                isCurrentMoveAFrontMove = !isCurrentMoveAFrontMove;
            }

            if (start < stringRoute.Length)
            {
                result.Add(stringRoute.Substring(start));
            }
            return result;
        }
    }
}