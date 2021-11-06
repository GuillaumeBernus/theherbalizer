
using System;

namespace MowerEngine.Models
{
    public class MowerPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction Orientation { get; set; }


        public void ApplyAction(Action action)
        {

            GetActionApplier(action).Apply(this);

            if (action == Action.R)
            {
                if (Orientation == Direction.W)
                {
                    Orientation = Direction.N;
                }
                else
                {
                    Orientation++;
                }
            }

            if (action == Action.L)
            {
                if (Orientation == Direction.N)
                {
                    Orientation = Direction.W;
                }
                else
                {
                    Orientation--;
                }
            }
            if (action == Action.F)
            {
                switch (Orientation)
                {
                    case Direction.N:
                        Y++;
                        break;
                    case Direction.E:
                        X++;
                        break;
                    case Direction.S:
                        Y--;
                        break;
                    case Direction.W:
                        X--;
                        break;
                    default:
                        break;
                }
            }
        }

        
    }
}


