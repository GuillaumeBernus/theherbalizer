using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowerEngine.Models
{
    public class Lawn
    {
        public Point UpperRigthCorner { get; set; }

        public IEnumerable<Mower> Mowers { get; set; }

        public IEnumerable<MowerPosition> RunMowers()
        {
            var result = new List<MowerPosition>(Mowers.Count());

            foreach (var mower in Mowers)
            {
                result.Add(mower.Run(this).StartPosition);
            }

            return result;
        }

        internal bool Contains(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X <= this.UpperRigthCorner.X && point.Y <= this.UpperRigthCorner.Y;
        }
    }
}
