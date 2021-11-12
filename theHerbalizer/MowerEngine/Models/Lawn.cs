using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class Lawn.
    /// </summary>
    public class Lawn
    {
        /// <summary>
        /// Gets or sets the upper rigth corner.
        /// </summary>
        /// <value>The upper rigth corner.</value>
        [Required]
        public Point UpperRigthCorner { get; set; }

        /// <summary>
        /// Gets or sets the mowers.
        /// </summary>
        /// <value>The mowers.</value>
        [Required]
        public List<Mower> Mowers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lawn"/> class.
        /// </summary>
        public Lawn()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lawn"/> class.
        /// </summary>
        /// <param name="mowers">The mowers.</param>
        /// <param name="upperRigthCorner">The upper rigth corner.</param>
        [JsonConstructor()]
        public Lawn(List<Mower> mowers, Point upperRigthCorner) : base()
        {
            this.UpperRigthCorner = upperRigthCorner;
            Parallel.ForEach(mowers, m => m.Lawn = this);
            this.Mowers = mowers;
        }

        /// <summary>
        /// Runs the mowers.
        /// </summary>
        /// <returns>List&lt;MowerPosition&gt;.</returns>
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