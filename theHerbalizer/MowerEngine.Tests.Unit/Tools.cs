using MowerEngine.Models;
using System;
using System.Text;

namespace MowerEngine.Tests.Unit
{
    public static class Tools
    {
        public static Mower GetRandomMower(Point upperRigthCorner, int maxRouteLength = 20)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return new Mower
            {
                Position = GetRandomMowerPosition(rnd, upperRigthCorner),
                Route = GetRandomRoute(rnd, maxRouteLength)
            };
        }

        public static string GetRandomRoute(Random rnd, int maxRouteLength)
        {
            char[] actions = { 'R', 'L', 'F' };

            var routeLength = rnd.Next(1, maxRouteLength);
            var route = new StringBuilder();
            for (int i = 0; i < routeLength; i++)
            {
                route.Append(actions[rnd.Next(0, 2)]);
            }
            return route.ToString();
        }

        public static MowerPosition GetRandomMowerPosition(Random rnd, Point upperRigthCorner)
        {
            return new MowerPosition
            {
                Coordinates = GetRandomPoint(rnd, upperRigthCorner),
                Orientation = (Direction)rnd.Next(0, 3)
            };
        }

        public static Point GetRandomPoint(Random rnd, Point upperRigthCorner)
        {
            return new Point
            {
                X = rnd.Next(upperRigthCorner?.X ?? 5),
                Y = rnd.Next(upperRigthCorner?.Y ?? 5)
            };
        }

        public static Mower GetMower(int X, int Y, Direction Orientation, string route)
        {
            return new Mower
            {
                Position = GetMowerPosition(X, Y, Orientation),
                Route = route,
            };
        }

        public static MowerPosition GetMowerPosition(int x, int y, Direction orientation)
        {
            return new MowerPosition
            {
                Coordinates = GetPoint(x, y),
                Orientation = orientation
            };
        }

        public static Point GetPoint(int x, int y)
        {
            return new Point { X = x, Y = y };
        }
    }
}