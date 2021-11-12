using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MowerEngine.Models
{
    public class Lawn
    {
        [Required]
        public Point UpperRigthCorner { get; set; }

        [Required]
        public List<Mower> Mowers { get; set; }

        public Lawn()
        {
        }

        [JsonConstructor()]
        public Lawn(List<Mower> mowers, Point upperRigthCorner) : base()
        {
            this.UpperRigthCorner = upperRigthCorner;
            Parallel.ForEach(mowers, m => m.Lawn = this);
            this.Mowers = mowers;
        }

        public List<MowerPosition> RunMowers()
        {
            var result = new List<MowerPosition>(Mowers.Count);
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();

                Parallel.ForEach(Mowers.AsParallel().AsOrdered(), mower =>
                {
                    result.Add(mower.Destination);
                });
                sw.Stop();
                long ms2 = sw.ElapsedMilliseconds;
            }
            catch (System.Exception e)
            {
                throw;
            }
            return result;
        }
    }
}