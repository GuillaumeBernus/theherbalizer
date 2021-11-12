using System.Collections.Generic;

namespace LawnFile.API.Configuration
{
    /// <summary>
    /// Class InputFileConfiguration.
    /// </summary>
    public class InputFileConfiguration
    {
        /// <summary>
        /// Gets or sets the allowed extensions.
        /// </summary>
        /// <value>The allowed extensions.</value>
        public IEnumerable<string> AllowedExtensions { get; set; }

        /// <summary>
        /// Gets or sets the maximum size octets.
        /// </summary>
        /// <value>The maximum size octets.</value>
        public int MaxSizeOctets { get; set; }
    }
}