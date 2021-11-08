
using System;

namespace MowerEngine.Models
{
    public class MowerPosition:ICloneable
    {

        public Point Position { get; set; }
        public Direction Orientation { get; set; }

        public override string ToString()
        {
            return $"{Position?.ToString() ?? String.Empty} {Orientation.ToString()}";
        }


        public MowerPosition ApplyAction(MowerAction action)
        {
            MowerPosition finalPoint = (MowerPosition)this.Clone();

            if (action == MowerAction.R)
            {
                if (finalPoint.Orientation == Direction.W)
                {
                    finalPoint.Orientation = Direction.N;
                }
                else
                {
                   finalPoint.Orientation++;
                }
            }

            if (action == MowerAction.L)
            {
                if (finalPoint.Orientation == Direction.N)
                {
                    finalPoint.Orientation = Direction.W;
                }
                else
                {
                    finalPoint.Orientation--;
                }
            }
            if (action == MowerAction.F)
            {
                switch (finalPoint.Orientation)
                {
                    case Direction.N:
                        finalPoint.Position.Y++;
                        break;
                    case Direction.E:
                        finalPoint.Position.X++;
                        break;
                    case Direction.S:
                        finalPoint.Position.Y--;
                        break;
                    case Direction.W:
                        finalPoint.Position.X--;
                        break;
                    default:
                        break;
                }
            }
            return finalPoint;
        }

        public object Clone()
        {
            MowerPosition clone = new MowerPosition();
            clone.Position = (Point)this.Position.Clone();
            clone.Orientation = this.Orientation;
            return clone;
        }
    }
}


