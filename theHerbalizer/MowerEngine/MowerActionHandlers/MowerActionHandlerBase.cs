using MowerEngine.Models;

namespace MowerEngine.MowerActionHandlers
{
    public abstract class MowerActionHandlerBase
    {
        public abstract void ApplyMowerAction(ref MowerPosition mowerPosition);
    }
}
