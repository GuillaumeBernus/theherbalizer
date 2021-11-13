using MowerEngine.Models.Exceptions;
using System.Linq;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class MoveParser.
    /// </summary>
    public static class MoveParser
    {
        /// <summary>
        /// Parses the specified string move.
        /// </summary>
        /// <param name="stringMove">The string move.</param>
        /// <returns>Move.</returns>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidMoveDescriptionException"></exception>
        public static Move Parse(string stringMove)
        {
            var move = new Move();
            if (stringMove.IsRotationDescription())
            {
                move.Type = MoveType.Rotation;
                move.Value = Constants.RightRotationFactor * stringMove.Count(_ => _ == Constants.RightRotationCharacter)
                    + Constants.LeftRotationFactor * stringMove.Count(_ => _ == Constants.LeftRotationCharacter);
            }
            else if (stringMove.IsFrontMoveDescription())
            {
                move.Type = MoveType.FrontMove;
                move.Value = stringMove.Count(_ => _ == Constants.FrontMoveCharacter);
            }
            else
            {
                throw new InvalidMoveDescriptionException();
            }

            return move;
        }
    }
}