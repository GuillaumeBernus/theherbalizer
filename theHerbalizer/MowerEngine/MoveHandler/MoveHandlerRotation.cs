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
        /// The direction count
        /// </summary>
        private const int DirectionCount = 4;

        /// <summary>
        /// Applies the mower move internal.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        public override void ApplyMowerMoveInternal(Mower mower, Move move)
        {
            int direction = ((int)mower.Position.Orientation + move.Value) % DirectionCount;
            if (direction < 0)
            {
                direction += DirectionCount;
            }
            mower.Position.Orientation = (Direction)direction;
        }
        /// <summary>
        /// Applies the move.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="lawn">The lawn.</param>
        /// <param name="move">The move.</param>
        /// <returns>MowerPosition.</returns>
        public override MowerPosition ApplyMove(MowerPosition start, Lawn lawn, Move move)
        {
            int direction = ((int)start.Orientation + move.Value) % DirectionCount;
            if (direction < 0)
            {
                direction += DirectionCount;
            }
            var finish = start with { Orientation= (Direction)direction };
            return finish;
        }

        /// <summary>
        /// Checks the specified mower.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        /// <exception cref="MowerEngine.Models.Exceptions.WrongMoveTypeException"></exception>
        public override void Check(Mower mower, Move move)
        {
            base.Check(mower, move);
            if (move.Type != MoveType.Rotation)
            {
                throw new WrongMoveTypeException();
            }
        }
    }
}