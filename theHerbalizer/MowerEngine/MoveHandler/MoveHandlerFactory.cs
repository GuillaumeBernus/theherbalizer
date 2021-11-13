using System.Collections.Generic;

namespace MowerEngine.Models.MoveHandler
{
    /// <summary>
    /// Class MoveHandlerFactory.
    /// </summary>
    internal static class MoveHandlerFactory
    {
        /// <summary>
        /// The handlers
        /// </summary>
        private static Dictionary<MoveType, MoveHandlerBase> handlers = new Dictionary<MoveType, MoveHandlerBase>()
        {
            { MoveType.FrontMove, new MoveHandlerFrontMove() },
            { MoveType.Rotation, new MoveHandlerRotation() }
        };

        /// <summary>
        /// Gets the move handler.
        /// </summary>
        /// <param name="move">The move.</param>
        /// <returns>MoveHandlerBase.</returns>
        public static MoveHandlerBase GetMoveHandler(Move move) => handlers[move.Type];
    }
}