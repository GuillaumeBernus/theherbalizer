using MowerEngine.Exceptions;
using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    /// <summary>
    /// Class MoveHandlerBase.
    /// </summary>
    public abstract class MoveHandlerBase
    {
        public MowerPosition MoveMower(MowerPosition start, Lawn lawn, Move move)
        {
            Check(lawn, move);
            return ApplyMove(start, lawn, move);
        }

        /// <summary>
        /// Applies the move.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="lawn">The lawn.</param>
        /// <param name="move">The move.</param>
        /// <returns>MowerPosition.</returns>
        protected abstract MowerPosition ApplyMove(MowerPosition start, Lawn lawn, Move move);

        /// <summary>
        /// Checks the specified mower.
        /// </summary>
        /// <param name="mower">The mower.</param>
        /// <param name="move">The move.</param>
        /// <exception cref="MowerEngine.Models.Exceptions.InvalidMowerException"></exception>
        /// <exception cref="MowerEngine.Models.MoveHandler.NullMoveException"></exception>
        protected virtual void Check(Lawn lawn, Move move)
        {
            if (lawn?.UpperRigthCorner == null)
            {
                throw new InvalidLawnException();
            }
            if (move == null)
            {
                throw new NullMoveException();
            }
        }
    }
}