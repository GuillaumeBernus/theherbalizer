using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
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
        public List<Mower> Mowers { get; private set; }

        /// <summary>
        /// Runs the mowers.
        /// </summary>
        /// <returns>List&lt;MowerPosition&gt;.</returns>
        public List<MowerPosition> RunMowers()
        {
            MowerPosition[] outputArray = new MowerPosition[Mowers.Count];

            var waitHandle = new ManualResetEvent(false);
            int counter = 0;

            Parallel.For(0, Mowers.Count, index =>
            {
                outputArray[index] = Mowers[index].Run();
                if (Interlocked.Increment(ref counter) == Mowers.Count - 1)
                {
                    waitHandle.Set();
                }
            });

            waitHandle.WaitOne();

            return outputArray.ToList();
        }

        /// <summary>
        /// Withes the mowers.
        /// </summary>
        /// <param name="mowers">The mowers.</param>
        /// <returns>Lawn.</returns>
        public Lawn WithMowers(List<Mower> mowers)
        {
            this.Mowers = mowers;
            Parallel.ForEach(mowers, m => m.Lawn = this);
            return this;
        }

        /// <summary>
        /// Withes the upper rigth corner.
        /// </summary>
        /// <param name="upperRigthCorner">The upper rigth corner.</param>
        /// <returns>Lawn.</returns>
        public Lawn WithUpperRigthCorner(Point upperRigthCorner)
        {
            this.UpperRigthCorner = upperRigthCorner;
            return this;
        }
    }
}