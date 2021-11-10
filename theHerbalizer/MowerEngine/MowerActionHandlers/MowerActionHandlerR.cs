using MowerEngine.Models;

namespace MowerEngine.MowerActionHandlers
{
    public class MowerActionHandlerR : MowerActionHandlerBase
    {
        public override void ApplyMowerAction(ref MowerPosition mowerPosition)
        {

            if (mowerPosition.Orientation == Direction.W)
            {
                mowerPosition.Orientation = Direction.N;
            }
            else
            {
                mowerPosition.Orientation++;
            }
        }
    }
}
