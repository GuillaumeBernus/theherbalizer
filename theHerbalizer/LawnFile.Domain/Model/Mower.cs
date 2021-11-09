using System;
using System.Collections.Generic;
using System.Linq;

namespace LawnFile.Domain.Model
{
    public class Mower
    {
        public MowerPosition StartPosition { get; set; }

        public IEnumerable<MowerAction> Route { get; set; }

        internal static List<Mower> FromMowerDescriptionList(IEnumerable<MowerDescription> mowerDescriptions)
        {
            return mowerDescriptions.Select(FromMowerDescription).ToList();
        }

        private static Mower FromMowerDescription(MowerDescription mowerDescription)
        {

            if(!MowerPosition.TryParse(mowerDescription.StartPosition,out MowerPosition startPosition))
            {
                throw new Exception("Wrong mower start position description");
            }

            if (!TryParseRoute(mowerDescription.Route, out IEnumerable<MowerAction> route))
            {
                throw new Exception("Wrong route description");
            }

            return new Mower
            {
                StartPosition = startPosition,
                Route = route
            };
        }

        private static bool TryParseRoute(string routeDescription, out IEnumerable<MowerAction> route)
        {
            var actionDescriptions = routeDescription.ToCharArray();

            
            
            var actionList= new List<MowerAction>(actionDescriptions.Length);

            foreach (var item in actionDescriptions)
            {
                if(!Enum.TryParse<MowerAction>(item.ToString(), out MowerAction action))
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