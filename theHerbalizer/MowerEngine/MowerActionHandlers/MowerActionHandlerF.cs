using MowerEngine.Models;

namespace MowerEngine.MowerActionHandlers
{
    public class MowerActionHandlerF : MowerActionHandlerBase
    {
        public override void ApplyMowerAction(ref MowerPosition mowerPosition)
        {
            switch (mowerPosition.Orientation)
            {
                case Direction.N:
                    mowerPosition.Coordinates.Y++;
                    break;
                case Direction.E:
                    mowerPosition.Coordinates.X++;
                    break;
                case Direction.S:
                    mowerPosition.Coordinates.Y--;
                    break;
                case Direction.W:
                    mowerPosition.Coordinates.X--;
                    break;
                default:
                    break;
            }
        }
    }
}
