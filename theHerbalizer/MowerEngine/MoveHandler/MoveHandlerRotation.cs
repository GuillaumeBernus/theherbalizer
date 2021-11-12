using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    public class MoveHandlerRotation : MoveHandlerBase
    {
        private const int DirectionCount = 4;

        public override void ApplyMowerMoveInternal(Mower mower, Move move)
        {
            int direction = ((int)mower.Position.Orientation + move.Value) % DirectionCount;
            if (direction < 0)
            {
                direction += DirectionCount;
            }
            mower.Position.Orientation = (Direction)direction;
        }
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