using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MowerPositionCloneTestsHandler
    {
        [Fact]
        public void Clone_WhenMowerPositionIsCloned_ReturnsEqualMowerPositiont()
        {
            Models.Point point = new Models.Point { X = 1, Y = 2 };
            Models.MowerPosition mowerPosition = new Models.MowerPosition { Coordinates=point, Orientation=Models.Direction.N };
            var clone = mowerPosition.Clone() as Models.MowerPosition;
            Assert.NotNull(clone);
            Assert.NotSame(mowerPosition, clone);
            Assert.Equal(mowerPosition.Coordinates.X, clone.Coordinates.X);
            Assert.Equal(mowerPosition.Coordinates.Y, clone.Coordinates.Y);
            Assert.Equal(mowerPosition.Orientation, clone.Orientation);
        }

    }
}
