
using MowerEngine.MowerActionHandlers;
using System;

namespace MowerEngine.Models
{
    public class MowerPosition:ICloneable
    {

        public Point Coordinates { get; set; }
        public Direction Orientation { get; set; }

        public override string ToString()
        {
            return $"{Coordinates?.ToString() ?? String.Empty} {Orientation.ToString()}";
        }


        public MowerPosition CloneAndApplyAction(MowerAction action)
        {
            MowerPosition finalPosition = this.Clone() as MowerPosition;
            MowerActionHandlerFactory.GetMowerActionHandler(action).ApplyMowerAction(ref finalPosition);
            return finalPosition;
        }

        public object Clone()
        {
            MowerPosition clone = new MowerPosition();
            clone.Coordinates = (Point)this.Coordinates.Clone();
            clone.Orientation = this.Orientation;
            return clone;
        }
    }
}


