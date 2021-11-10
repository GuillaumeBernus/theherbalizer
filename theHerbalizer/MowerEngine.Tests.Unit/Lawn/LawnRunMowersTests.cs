using MowerEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class LawnRunMowersTests
    {
        //[Fact]
        //public void RunMowers_WhenMultipleMowers_ReturnsResultsInSameOrder()
        //{
        //    var lawn = new Lawn()
        //    {
        //        Mowers = new List<Mower>
        //        {
        //          GetRandomMower

        //        }

        //    };
        //}



        private static Mower GetRandomMower(Point upperRigthCorner, int maxRouteLength)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return new Mower
            {
                Position = GetRandomMowerPosition(rnd,upperRigthCorner),
                Route = GetRandomRoute(rnd,maxRouteLength)
            };

        }

        private static List<MowerAction> GetRandomRoute(Random rnd,int maxRouteLength)
        {
            

            var routeLength = rnd.Next(1,maxRouteLength);
            var route = new List<MowerAction>();
            for (int i = 0; i < routeLength; i++)
            {
                route.Add((MowerAction)rnd.Next(0, 2));
            }
            return route;
        }
        private static MowerPosition GetRandomMowerPosition(Random rnd, Point upperRigthCorner)
        {
            return new MowerPosition
            {
                Coordinates = GetRandomPoint(rnd,upperRigthCorner),
                Orientation = (Direction)rnd.Next(0, 3)
            };

        }
            private static Point GetRandomPoint(Random rnd,Point upperRigthCorner)
        {

            return new Point
            {
                X = rnd.Next(upperRigthCorner?.X ?? 5),
                Y = rnd.Next(upperRigthCorner?.Y ?? 5)
            };
        }
    }
}
