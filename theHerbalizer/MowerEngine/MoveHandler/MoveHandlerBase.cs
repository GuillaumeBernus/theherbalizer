using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    /// <summary>
    /// Class MoveHandlerBase.
    /// </summary>
    public abstract class MoveHandlerBase
    {
        /// <summary>
        /// Applies the mower move internal.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        public abstract void ApplyMowerMoveInternal(Mower mower, Move move);

        /// <summary>
        /// Moves the mower.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        public void MoveMower(Mower mower, Move move)
        {
            Check(mower, move);
            ApplyMowerMoveInternal(mower, move);
        }

        /// <summary>
        /// Applies the move.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="lawn">The lawn.</param>
        /// <param name="move">The move.</param>
        /// <returns>MowerPosition.</returns>
        public abstract MowerPosition ApplyMove(MowerPosition start, Lawn lawn, Move move);

        /// <summary>
        /// Checks the specified mower.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidMowerException"></exception>
        /// <exception cref="MowerEngine.Models.MoveHandler.NullMoveException"></exception>
        public virtual void Check(Mower mower, Move move)
        {
            if (mower == null)
            {
                throw new InvalidMowerException();
            }
            if (move == null)
            {
                throw new NullMoveException();
            }
        }
    }
}