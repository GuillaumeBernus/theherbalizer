using MowerEngine.Models;
using MowerEngine.Models.Exceptions;
using MowerEngine.Models.MoveHandler;
using System.Collections.Generic;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MoveHandlerRotationTests
    {
        private readonly MoveHandlerRotation handler;
        private Lawn _lawn;
        private MowerPosition _startPosition;

        public MoveHandlerRotationTests()
        {
            handler = new MoveHandlerRotation();
            _lawn = new Lawn { UpperRigthCorner = Tools.GetPoint(5, 5) };
            _startPosition = Tools.GetMowerPosition(0, 0, Direction.N);
        }

        [Fact]
        public void MoveMower_WhenMoveIsFrontMove_ThrowsWrongMoveTypeException()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = 1 };

            Assert.Throws<InvalidMoveTypeException>(() => handler.MoveMower(_startPosition, _lawn, move));
        }

        [Fact]
        public void MoveMower_WhenMoveIsNull_ThrowsNullMoveException()
        {
            Assert.Throws<NullMoveException>(() => handler.MoveMower(_startPosition, _lawn, null));
        }

        [Theory]
        [InlineData(1, Direction.E)]
        [InlineData(-1, Direction.W)]
        [InlineData(4, Direction.N)]
        [InlineData(-7, Direction.E)]
        public void RunMoveMowerTests_Start00N(int moveValue, Direction expectedDirection)
        {
            var move = new Move { Type = MoveType.Rotation, Value = moveValue };
            var expected = Tools.GetMowerPosition(0, 0, expectedDirection);

            var actual = handler.MoveMower(_startPosition, _lawn, move);

            Assert.NotNull(actual?.Coordinates);
            Assert.Equal(actual!.Coordinates.X, expected.Coordinates.X);
            Assert.Equal(actual!.Coordinates.Y, expected.Coordinates.Y);
            Assert.Equal(actual!.Orientation, expected.Orientation);
        }
    }
}