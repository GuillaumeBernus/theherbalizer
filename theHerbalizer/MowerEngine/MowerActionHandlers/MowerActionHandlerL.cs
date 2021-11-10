using MowerEngine.Models;

namespace MowerEngine.MowerActionHandlers
{
    public class MowerActionHandlerL: MowerActionHandlerBase
    {
        public override void ApplyMowerAction(ref MowerPosition mowerPosition)
        {
            if (mowerPosition.Orientation == Direction.N)
            {
                mowerPosition.Orientation = Direction.W;
            }
            else
            {
                mowerPosition.Orientation--;
            }
        }
    }
}
