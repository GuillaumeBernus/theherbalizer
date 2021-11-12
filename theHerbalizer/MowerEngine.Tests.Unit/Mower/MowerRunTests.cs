using MowerEngine.Exceptions;
using MowerEngine.Models;
using System.Collections.Generic;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MowerRunTests
    {
        [Theory]
        [InlineData("FFF", 0, 3, Direction.N)]
        [InlineData("FRFFFF", 4, 1, Direction.E)]
        [InlineData("FRFFLF", 2, 2, Direction.N)]
        [InlineData("FFFFFFFFFFFFFFFFRFFFFFFFFFFFFFFFFFFLLFLF", 4, 4, Direction.S)]
        [InlineData("RFFFFFLFFFFFLFFLFFFF", 3, 1, Direction.S)]
        public void RunTests_WhenLawnIs5On5AndStartPositionIs00N(string route, int expectedX, int expectedY, Direction expectedOrientation)
        {
            var expectedPosition = Tools.GetMowerPosition(expectedX, expectedY, expectedOrientation);

            var lawn = new Lawn
            {
                Mowers = new List<Mower>(),
                UpperRigthCorner = Tools.GetPoint(5, 5)
            };

            var mower = Tools.GetMower(0, 0, Direction.N, route, lawn);

            mower.Run();
            Assert.Equal(expectedPosition, mower.Position);
        }

        [Fact]
        public void Run_WhenLawnIsNull_ThrowsInvalidLawnException()
        {
            var mower = Tools.GetMower(0, 0, Direction.N, "FF", null);

            Assert.Throws<InvalidLawnException>(() => mower.Run());
        }
    }
}