using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    /// <summary>
    /// Class MoveHandlerRotation.
    /// Implements the <see cref="MowerEngine.Models.MoveHandler.MoveHandlerBase" />
    /// </summary>
    /// <seealso cref="MowerEngine.Models.MoveHandler.MoveHandlerBase" />
    public class MoveHandlerRotation : MoveHandlerBase
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
            int direction = ((int)start.Orientation + move.Value) % Constants.DirectionCount;
            if (direction < 0)
            {
                direction += Constants.DirectionCount;
            }
            var finish = start.Clone() as MowerPosition;
            finish.Orientation = (Direction)direction;
            return finish;
        }

        /// <summary>
        /// Checks the specified mower.
        /// </summary>
        /// <param name="lawn">The lawn.</param>
        /// <param name="move">The move.</param>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidMoveTypeException"></exception>
        protected override void Check(Lawn lawn, Move move)
        {
            base.Check(lawn, move);
            if (move.Type != MoveType.Rotation)
            {
                throw new InvalidMoveTypeException();
            }
        }
    }
}