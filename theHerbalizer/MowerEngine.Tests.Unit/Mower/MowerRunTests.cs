using MowerEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MowerRunTests
    {
        [Fact]
        public void Run_WhenOutOfTheLawn_ReturnsSamePosition()
        {
            var expectedPosition = new MowerPosition
            {
                Coordinates = new Point { X = 2, Y = 5 },
                Orientation = Direction.N
            };
            

            var lawn = new Lawn
            {
                Mowers = new List<Mower> (),
                UpperRigthCorner = new Point { X = 5, Y = 5 }
            };

            var mower = new Mower
            {
                Position = expectedPosition.Clone() as MowerPosition,
                Route = new List<MowerAction> { MowerAction.F },
                Lawn = lawn
            };
            lawn.Mowers.Add(mower);

            mower.Run();
            Assert.Equal(expectedPosition.Orientation, mower.Position.Orientation);
            Assert.NotNull(mower.Position.Coordinates);
            Assert.Equal(expectedPosition.Coordinates.X, mower.Position.Coordinates.X);
            Assert.Equal(expectedPosition.Coordinates.Y, mower.Position.Coordinates.Y);
        }


    }
}
