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

        public MoveHandlerRotationTests()
        {
            handler = new MoveHandlerRotation();
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMoveIsFrontMove_ThrowsWrongMoveTypeException()
        {
            var move = new Move { Type = MoveType.FrontMove, Value = 1 };

            var mower = Tools.GetMower(0, 0, Direction.N, "", null);

            var lawn = new Lawn(new List<Mower> { mower }, Tools.GetPoint(5, 5));
            
            Assert.Throws<WrongMoveTypeException>(() => handler.MoveMower(mower, move));
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMowerIsNull_ThrowsInvalidMowerException()
        {
            var move = new Move { Type = MoveType.Rotation, Value = 1 };

            Assert.Throws<InvalidMowerException>(() => handler.MoveMower(null, move));
        }

        [Fact]
        public void RunTestsApplyMowerMove_WhenMoveIsNull_ThrowsNullMoveException()
        {
            var mower = Tools.GetMower(0, 0, Direction.N, "", null);

            var lawn = new Lawn(new List<Mower> { mower }, Tools.GetPoint(5, 5));

            Assert.Throws<NullMoveException>(() => handler.MoveMower(mower, null));
        }

        [Theory]
        [InlineData(1, Direction.E)]
        [InlineData(-1, Direction.W)]
        [InlineData(4, Direction.N)]
        [InlineData(-7, Direction.E)]
        public void RunTestsApplyMowerMove_Start00N(int moveValue, Direction expectedDirection)
        {
            var move = new Move { Type = MoveType.Rotation, Value = moveValue };
            var expected = Tools.GetMowerPosition(0, 0, expectedDirection);
            var mower = Tools.GetMower(X: 0, Y: 0, Orientation: Direction.N, "R", null);

            handler.MoveMower(mower, move);

            Assert.Equal(mower.Position, expected);
        }
    }
}