using System.Collections.Generic;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class LawnDescription.
    /// </summary>
    internal class LawnDescription
    {
        /// <summary>
        /// Gets or sets the upper right corner.
        /// </summary>
        /// <value>The upper right corner.</value>
        public string UpperRightCorner { get; set; }

        /// <summary>
        /// Gets or sets the mower descriptions.
        /// </summary>
        /// <value>The mower descriptions.</value>
        public List<MowerDescription> MowerDescriptions { get; set; }
    }
}