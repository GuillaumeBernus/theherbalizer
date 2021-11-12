using MowerEngine.Exceptions;
using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    public class MoveHandlerFrontMove : MoveHandlerBase
    {
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