using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawnFileAPI.Configuration
{
    public class InputFileConfiguration
    {

        public IEnumerable<string> AllowedExtensions { get; set; }


        public int MaxSizeOctets { get; set; }
    }
}
