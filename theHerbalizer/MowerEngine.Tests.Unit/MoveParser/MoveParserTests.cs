﻿using MowerEngine.Models;
using MowerEngine.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class MoveParserTests
    {

        [Fact]
        public void Parse_WhenStringMoveIsEmpty_ThrowsInvalidMoveDescriptionException()
        {
            Assert.Throws<InvalidMoveDescriptionException>(() => MoveParser.Parse(""));
        }
        [Fact]
        public void Parse_WhenStringMoveMixRotationAndFrontMove_ThrowsInvalidMoveDescriptionException()
        {
            Assert.Throws<InvalidMoveDescriptionException>(() => MoveParser.Parse("LRFFLR"));
        }

        [Fact]
        public void Parse_WhenStringMoveContainsWrongCharacters_ThrowsInvalidMoveDescriptionException()
        {
            Assert.Throws<InvalidMoveDescriptionException>(() => MoveParser.Parse("XLFRLB1234"));
        }


        [Theory]
        [InlineData("LRLLRRRRR",MoveType.Rotation,3)]
        [InlineData("RRRRR", MoveType.Rotation, 5)]
        [InlineData("LLLLL", MoveType.Rotation, -5)]
        [InlineData("FFFFF", MoveType.FrontMove, 5)]
        [InlineData("FFFFFFF", MoveType.FrontMove, 7)]
        public void Parse_RunCorrectMoveDescrition(string moveDescription, MoveType expectedMoveType, int expectedValue)
        {

            var move = MoveParser.Parse(moveDescription);

            Assert.Equal(move.Type, expectedMoveType);
            Assert.Equal(move.Value, expectedValue);

        }
    }
}
