using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowerEngine.Models
{
    public class Field
    {
        public int Size { get; set; }

        public IEnumerable<Mower> Mowers { get; set; }

        public IEnumerable<MowerPosition> RunMowers()
        {
            var result = new List<MowerPosition>(Mowers.Count());

            foreach (var mower in Mowers)
            {
                result.Add(mower.Run(Size));
            }

            return result;
        }

    }
}
