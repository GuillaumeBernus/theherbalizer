using MowerEngine.Models;
using System;
using System.Linq;

namespace Lawn.API.Models
{
    /// <summary>
    /// Class LawnCommandAssembler.
    /// </summary>
    public static class LawnCommandAssembler
    {
        /// <summary>
        /// Converts to lawn.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>MowerEngine.Models.Lawn.</returns>
        public static MowerEngine.Models.Lawn ToLawn(LawnCommand viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            return new MowerEngine.Models.Lawn().WithMowers(viewModel.Mowers.Select(m => ToMower(m)).ToList()).WithUpperRigthCorner(ToPoint(viewModel.UpperRigthCorner));
        }

        /// <summary>
        /// Converts to mower.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>Mower.</returns>
        private static Mower ToMower(MowerViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            return new Mower
            {
                Position = ToMowerPosition(viewModel.StartPosition)
                ,
                Route = viewModel.Route
            };
        }

        /// <summary>
        /// Converts to mowerposition.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>MowerPosition.</returns>
        private static MowerPosition ToMowerPosition(MowerPositionViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }
            if (!Enum.TryParse<Direction>(viewModel.Orientation, out Direction orientation))
            {
                return null;
            }

            return new MowerPosition
            {
                Coordinates = ToPoint(viewModel.Coordinates),
                Orientation = orientation
            };
        }

        /// <summary>
        /// Converts to point.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>Point.</returns>
        public static Point ToPoint(PointViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }
            return new Point
            {
                X = viewModel.X,
                Y = viewModel.Y
            };
        }
    }
}