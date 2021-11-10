using MowerEngine.Models;
using MowerEngine.MowerActionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MowerActionHandlerTests
    {

        [Fact]
        public void MowerActionHandlerL_WhenOrientationIsN_ReturnsSameCoordinatesOrientationE()
        {
            var handler = new MowerActionHandlers.MowerActionHandlerL();
            var position = GetMowerPosition(1, 2, Direction.N);
            var expected = GetMowerPosition(1, 2, Direction.W);

            handler.ApplyMowerAction(ref position);
            AssertPositionsEquality( position, expected);
        }
        [Fact]
        public void MowerActionHandlerR_WhenOrientationIsN_ReturnsSameCoordinatesOrientationW()
        {
           
            var handler = new MowerActionHandlers.MowerActionHandlerR();
            var position = GetMowerPosition(1, 2, Direction.N);
            var expected = GetMowerPosition(1, 2, Direction.E);

            handler.ApplyMowerAction(ref position);
            AssertPositionsEquality(position, expected);

        }
        [Fact]
        public void MowerActionHandlerF_WhenOrientationIsN_ReturnsIncreasedYSameOrientation()
        {
            var handler = new MowerActionHandlers.MowerActionHandlerF();
            var position = GetMowerPosition(1, 2, Direction.N);
            var expected = GetMowerPosition(1, 3, Direction.N);

            handler.ApplyMowerAction(ref position);
            AssertPositionsEquality(position, expected);
        }

        [Fact]
        public void MowerActionHandlerF_WhenOrientationIsS_ReturnsDecreasedYSameOrientation()
        {
            var handler = new MowerActionHandlers.MowerActionHandlerF();
            var position = GetMowerPosition(1, 2, Direction.S);
            var expected = GetMowerPosition(1, 1, Direction.S);

            handler.ApplyMowerAction(ref position);
            AssertPositionsEquality(position, expected);
        }

        [Fact]
        public void MowerActionHandlerF_WhenOrientationIsE_ReturnsIncreasedXSameOrientation()
        {

            var handler = new MowerActionHandlers.MowerActionHandlerF();
            var position = GetMowerPosition(1, 2, Direction.E);
            var expected = GetMowerPosition(2, 2, Direction.E);

            handler.ApplyMowerAction(ref position);
            AssertPositionsEquality(position, expected);

        }

        [Fact]
        public void MowerActionHandlerF_WhenOrientationIsW_ReturnsDecreasedXSameOrientation()
        {

            var handler = new MowerActionHandlers.MowerActionHandlerF();
            var position = GetMowerPosition(1, 2, Direction.W);
            var expected = GetMowerPosition(0, 2, Direction.W);

            handler.ApplyMowerAction(ref position);
            AssertPositionsEquality(position, expected);

        }

        private void AssertPositionsEquality( MowerPosition position, MowerPosition expected)
        {
            Assert.Equal(expected.Orientation, position.Orientation);
            Assert.NotNull(position.Coordinates);
            Assert.Equal(expected.Coordinates.X, position.Coordinates.X);
            Assert.Equal(expected.Coordinates.Y, position.Coordinates.Y);
        }

        private MowerPosition GetMowerPosition(int x, int y, Direction orientation)
        {
            return new MowerPosition
            {
                Coordinates = new Point { X = x, Y = y }
                    ,
                Orientation = orientation
            };
        }
    }
}
