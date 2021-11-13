using MowerEngine.Exceptions;
using MowerEngine.Models;
using MowerEngine.Models.Exceptions;
using MowerEngine.Models.MoveHandler;
using System.Collections.Generic;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MoveHandlerFrontMoveTests
    {
        private readonly MoveHandlerFrontMove handler;
        private Lawn _lawn;
        private MowerPosition _startPosition;

        public MoveHandlerFrontMoveTests()
        {
            handler = new MoveHandlerFrontMove();
            _lawn = new Lawn { UpperRigthCorner = Tools.GetPoint(5, 5) };
            _startPosition = Tools.GetMowerPosition(0, 0, Direction.N);
        }

        [Fact]
        public void MoveMower_WhenLawnIsNull_ThrowsInvalidLawnException()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = 1 };

            Assert.Throws<InvalidLawnException>(() => handler.MoveMower(_startPosition, null, move));
        }

        [Fact]
        public void MoveMower_WhenMoveIsRotational_ThrowsWrongMoveTypeException()
        {
            var move = new Move { Type = MoveType.Rotation, Value = 1 };

            Assert.Throws<InvalidMoveTypeException>(() => handler.MoveMower(_startPosition, _lawn, move));
        }

        [Fact]
        public void MoveMower_WhenMoveValueIsNegative_ThrowsInvalidValueForFrontMove()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = -1 };

            Assert.Throws<InvalidValueForFrontMoveException>(() => handler.MoveMower(_startPosition, _lawn, move));
        }

        [Fact]
        public void MoveMower_WhenMoveIsNull_ThrowsNullMoveException()
        {
            Assert.Throws<NullMoveException>(() => handler.MoveMower(_startPosition, _lawn, null));
        }

        [Theory]
        [InlineData(0, 0, Direction.N, 1, 0, 1)]
        [InlineData(0, 0, Direction.N, 10, 0, 5)]
        [InlineData(0, 0, Direction.E, 1, 1, 0)]
        [InlineData(0, 0, Direction.E, 10, 5, 0)]
        [InlineData(0, 0, Direction.S, 1, 0, 0)]
        [InlineData(0, 5, Direction.S, 1, 0, 4)]
        [InlineData(0, 5, Direction.S, 10, 0, 0)]
        [InlineData(0, 0, Direction.W, 1, 0, 0)]
        [InlineData(5, 0, Direction.W, 1, 4, 0)]
        [InlineData(5, 0, Direction.W, 10, 0, 0)]
        public void RunMoveMowerTests_LawnOf5(int initialX, int initialY, Direction orientation, int moveValue, int expectedX, int expectedY)
        {
            var move = new Move { Type = MoveType.FrontMove, Value = moveValue };
            var expected = Tools.GetMowerPosition(expectedX, expectedY, orientation);
            _startPosition = Tools.GetMowerPosition(initialX, initialY, orientation);

            var actual = handler.MoveMower(_startPosition, _lawn, move);

            Assert.NotNull(actual?.Coordinates);
            Assert.Equal(actual.Coordinates.X, expected.Coordinates.X);
            Assert.Equal(actual.Coordinates.Y, expected.Coordinates.Y);
            Assert.Equal(actual.Orientation, expected.Orientation);
        }
    }
}