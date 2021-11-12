using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    public abstract class MoveHandlerBase
    {
        public abstract void ApplyMowerMoveInternal(Mower mower, Move move);

        public void MoveMower(Mower mower, Move move)
        {
            Check(mower, move);
            ApplyMowerMoveInternal(mower, move);
        }

        public abstract MowerPosition ApplyMove(MowerPosition start, Lawn lawn, Move move);

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