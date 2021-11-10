using System.Collections.Generic;
using System.Linq;
namespace MowerEngine.Models
{
    public class Lawn
    {
        public Point UpperRigthCorner { get; set; }

        public List<Mower> Mowers { get; set; }


        public List<MowerPosition> RunMowers
        {
            get
            {
                var result = new List<MowerPosition>(Mowers.Count);

                foreach (var mower in Mowers)
                {
                    result.Add(mower.Run(this).Position);
                }

                return result;
            }
        }

        internal bool Contains(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X <= this.UpperRigthCorner.X && point.Y <= this.UpperRigthCorner.Y;
        }
    }
}
