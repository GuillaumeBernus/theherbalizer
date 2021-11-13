using MowerEngine.Exceptions;
using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    /// <summary>
    /// Class MoveHandlerFrontMove.
    /// Implements the <see cref="MowerEngine.Models.MoveHandler.MoveHandlerBase" />
    /// </summary>
    /// <seealso cref="MowerEngine.Models.MoveHandler.MoveHandlerBase" />
    public class MoveHandlerFrontMove : MoveHandlerBase
    {
        /// <summary>
        /// Applies the move.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="lawn">The lawn.</param>
        /// <param name="move">The move.</param>
        /// <returns>MowerPosition.</returns>
        protected override MowerPosition ApplyMove(MowerPosition start, Lawn lawn, Move move)
        {
            var finish = start.Clone() as MowerPosition;
            switch (finish.Orientation)
            {
                case Direction.N:
                    finish.Coordinates.Y = System.Math.Min(finish.Coordinates.Y + move.Value, lawn.UpperRigthCorner.Y);
                    break;

                case Direction.E:
                    finish.Coordinates.X = System.Math.Min(finish.Coordinates.X + move.Value, lawn.UpperRigthCorner.X);
                    break;

                case Direction.S:
                    finish.Coordinates.Y = System.Math.Max(finish.Coordinates.Y - move.Value, Constants.LawnMinY);
                    break;

                case Direction.W:
                    finish.Coordinates.X = System.Math.Max(finish.Coordinates.X - move.Value, Constants.LawnMinX);
                    break;

                default:
                    break;
            }
            return finish;
        }

        /// <summary>
        /// Checks the specified mower.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        /// <exception cref="MowerEngine.Exceptions.InvalidLawnException"></exception>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidMoveTypeException"></exception>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidValueForFrontMoveException"></exception>
        protected override void Check(Lawn lawn, Move move)
        {
            base.Check(lawn, move);

            if (move.Type != MoveType.FrontMove)
            {
                throw new InvalidMoveTypeException();
            }

            if (move.Value < 0)
            {
                throw new InvalidValueForFrontMoveException();
            }
        }
    }
}