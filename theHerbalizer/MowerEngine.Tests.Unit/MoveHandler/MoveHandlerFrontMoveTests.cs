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

        public MoveHandlerFrontMoveTests()
        {
            handler = new MoveHandlerFrontMove();
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenLawnIsNull_ThrowsInvalidLawnException()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = 1 };

            var mower = Tools.GetMower(0, 0, Direction.N, "", null);

            Assert.Throws<InvalidLawnException>(() => handler.MoveMower(mower, move));
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMowerIsNull_ThrowsInvalidMowerException()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = 1 };

            Assert.Throws<InvalidMowerException>(() => handler.MoveMower(null, move));
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMoveIsRotational_ThrowsWrongMoveTypeException()
        {
            var move = new Move { Type = MoveType.Rotation, Value = 1 };

            var mower = Tools.GetMower(0, 0, Direction.N, "", null);

            var lawn = new Lawn(new List<Mower> { mower });
            lawn.UpperRigthCorner = Tools.GetPoint(5, 5);

            Assert.Throws<WrongMoveTypeException>(() => handler.MoveMower(mower, move));
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMoveValueIsNegative_ThrowsInvalidValueForFrontMove()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = -1 };

            var mower = Tools.GetMower(0, 0, Direction.N, "", null);

            var lawn = new Lawn(new List<Mower> { mower });
            lawn.UpperRigthCorner = Tools.GetPoint(5, 5);

            Assert.Throws<InvalidValueForFrontMoveException>(() => handler.MoveMower(mower, move));
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMoveIsNull_ThrowsNullMoveException()
        {
            var mower = Tools.GetMower(0, 0, Direction.N, "", null);

            var lawn = new Lawn(new List<Mower> { mower });
            lawn.UpperRigthCorner = Tools.GetPoint(5, 5);

            Assert.Throws<NullMoveException>(() => handler.MoveMower(mower, null));
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
        public void RunTestsApplyMowerMove_LawnOf5(int initialX, int initialY, Direction orientation, int moveValue, int expectedX, int expectedY)
        {
            var move = new Move { Type = MoveType.FrontMove, Value = moveValue };
            var expected = Tools.GetMowerPosition(expectedX, expectedY, orientation);

            var mower = Tools.GetMower(X: initialX, Y: initialY, Orientation: orientation, "", null);

            var lawn = new Lawn(new List<Mower> { mower });
            lawn.UpperRigthCorner = Tools.GetPoint(5, 5);

            handler.MoveMower(mower, move);

            Assert.Equal(mower.Position, expected);
        }
    }
}