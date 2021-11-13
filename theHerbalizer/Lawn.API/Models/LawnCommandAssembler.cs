using MowerEngine.Models;
using System;
using System.Linq;

namespace Lawn.API.Models
{
    public static class LawnCommandAssembler
    {
        public static MowerEngine.Models.Lawn ToLawn(LawnCommand viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            return new MowerEngine.Models.Lawn().WithMowers(viewModel.Mowers.Select(m => ToMower(m)).ToList()).WithUpperRigthCorner(ToPoint(viewModel.UpperRigthCorner));
        }

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