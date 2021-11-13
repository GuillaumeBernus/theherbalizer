using LawnFile.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LawnFile.Domain.Model
{
    public static class MowerParser
    {
        /// <summary>
        /// Froms the mower description list.
        /// </summary>
        /// <param name="mowerDescriptions">The mower descriptions.</param>
        /// <returns>List&lt;Mower&gt;.</returns>
        internal static List<Mower> FromMowerDescriptionList(List<MowerDescription> mowerDescriptions)
        {
            Mower[] outputArray = new Mower[mowerDescriptions.Count];

            var loopEnd = mowerDescriptions.Count;

            var waitHandle = new ManualResetEvent(false);
            int counter = 0;

            Parallel.For(0, mowerDescriptions.Count, index =>
            {
                outputArray[index] = FromMowerDescription(mowerDescriptions[index]);

                if (Interlocked.Increment(ref counter) == mowerDescriptions.Count - 1)
                {
                    waitHandle.Set();
                }
            });

            waitHandle.WaitOne();

            return outputArray.ToList();
        }

        /// <summary>
        /// Froms the mower description.
        /// </summary>
        /// <param name="mowerDescription">The mower description.</param>
        /// <returns>Mower.</returns>
        /// <exception cref="System.Exception">Wrong mower start position description</exception>
        /// <exception cref="System.Exception">Wrong route description</exception>
        public static Mower FromMowerDescription(MowerDescription mowerDescription)
        {
            if (!MowerPositionParser.TryParse(mowerDescription.StartPosition, out MowerPosition startPosition))
            {
                throw new Exception("Wrong mower start position description");
            }

            if (!mowerDescription.Route.IsMowerRoute())
            {
                throw new Exception("Wrong route description");
            }

            return new Mower
            {
                StartPosition = startPosition,
                Route = mowerDescription.Route
            };
        }
    }
}