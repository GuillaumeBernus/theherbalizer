using MowerEngine.Exceptions;
using System.Collections.Generic;

namespace MowerEngine.Models
{
    public static class TravelParser
    {
        public static List<Move> Parse(string routeDescription)
        {
            var stringMoves = SplitRoute(routeDescription);
            var travel = new List<Move>();
            stringMoves.ForEach(m => travel.Add(MoveParser.Parse(m)));
            return travel;
        }

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