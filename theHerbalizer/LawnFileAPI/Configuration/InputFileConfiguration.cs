using System.Collections.Generic;

namespace LawnFile.API.Configuration
{
    public class InputFileConfiguration
    {
        public IEnumerable<string> AllowedExtensions { get; set; }

        public int MaxSizeOctets { get; set; }
    }
}