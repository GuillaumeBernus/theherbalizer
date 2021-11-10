using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class PointCloneTests
    {
        [Fact]
        public void Clone_WhenPointIsCloned_ReturnsEqualPoint()
        {
            Models.Point point= new Models.Point { X = 1, Y = 2 };
            var clone = point.Clone() as Models.Point;
            Assert.NotSame(point, clone);
            Assert.NotNull(clone);
            Assert.Equal(point.X,clone.X);
            Assert.Equal(point.Y, clone.Y);
        }
    }
}
