using MowerEngine.Exceptions;
using MowerEngine.Models;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class TravelParserTests
    {

        [Theory]
        [InlineData("")]
        [InlineData("AZERTY")]
        [InlineData("123456789")]
        [InlineData("LLRRFFRRFLX")]
        public void Parse_WhenInputIsNotValid_ThrowsInvalidRouteDescriptionException(string routeDescription)
        {
            Assert.Throws<InvalidRouteDescriptionException>(()=> TravelParser.Parse(routeDescription));
        }


        [Theory]
        [InlineData("FF",1,MoveType.FrontMove,2, MoveType.FrontMove, 2)]
        [InlineData("LRLRFFLLLFFF", 4, MoveType.Rotation, 0, MoveType.FrontMove, 3)]
        public void Parse_WhenInputIsValid_ReturnsExpectedMoves(string routeDescription, int expectedMovesCount, MoveType firstExpectedMoveType, int firstExpectedValue, MoveType lastExpectedMoveType, int lastExpectedValue)
        {
            var actual= TravelParser.Parse(routeDescription);

            Assert.NotNull(actual);
            Assert.Equal(expectedMovesCount, actual.Count);
            Assert.Equal(firstExpectedMoveType, actual[0].Type);
            Assert.Equal(firstExpectedValue, actual[0].Value);

            Assert.Equal(lastExpectedMoveType, actual[actual.Count-1].Type);
            Assert.Equal(lastExpectedValue, actual[actual.Count - 1].Value);
        }


    }
}
