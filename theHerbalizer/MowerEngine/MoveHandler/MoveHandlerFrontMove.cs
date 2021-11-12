using MowerEngine.Exceptions;
using MowerEngine.Models.Exceptions;

namespace MowerEngine.Models.MoveHandler
{
    public class MoveHandlerFrontMove : MoveHandlerBase
    {
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