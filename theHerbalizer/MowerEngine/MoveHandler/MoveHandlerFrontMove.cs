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
        public override MowerPosition ApplyMove(MowerPosition start, Lawn lawn, Move move)
        {

            var finish = start with { };
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
        /// Applies the mower move internal.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        public override void ApplyMowerMoveInternal(Mower mower, Move move)
        {
            switch (mower.Position.Orientation)
            {
                case Direction.N:
                    mower.Position.Coordinates.Y = System.Math.Min(mower.Position.Coordinates.Y + move.Value, mower.Lawn.UpperRigthCorner.Y);
                    break;

                case Direction.E:
                    mower.Position.Coordinates.X = System.Math.Min(mower.Position.Coordinates.X + move.Value, mower.Lawn.UpperRigthCorner.X);
                    break;

                case Direction.S:
                    mower.Position.Coordinates.Y = System.Math.Max(mower.Position.Coordinates.Y - move.Value, Constants.LawnMinY);
                    break;

                case Direction.W:
                    mower.Position.Coordinates.X = System.Math.Max(mower.Position.Coordinates.X - move.Value, Constants.LawnMinX);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Checks the specified mower.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        /// <exception cref="MowerEngine.Exceptions.InvalidLawnException"></exception>
        /// <exception cref="MowerEngine.Models.Exceptions.WrongMoveTypeException"></exception>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidValueForFrontMoveException"></exception>
        public override void Check(Mower mower, Move move)
        {
            base.Check(mower, move);

            if (mower!.Lawn?.UpperRigthCorner == null)
            {
                throw new InvalidLawnException();
            }

            if (move.Type != MoveType.FrontMove)
            {
                throw new WrongMoveTypeException();
            }

            if (move.Value < 0)
            {
                throw new InvalidValueForFrontMoveException();
            }
        }
    }
}