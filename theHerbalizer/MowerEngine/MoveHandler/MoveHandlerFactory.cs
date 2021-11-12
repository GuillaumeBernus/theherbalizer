using System.Collections.Generic;

namespace MowerEngine.Models.MoveHandler
{
    internal static class MoveHandlerFactory
    {
        private static Dictionary<MoveType, MoveHandlerBase> handlers = new Dictionary<MoveType, MoveHandlerBase>()
        {
            { MoveType.FrontMove, new MoveHandlerFrontMove() },
            { MoveType.Rotation, new MoveHandlerRotation() }
        };

        public static MoveHandlerBase GetMoveHandler(Move move) => handlers[move.Type];
    }
}