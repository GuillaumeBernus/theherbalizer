using System.Collections.Generic;

namespace LawnFile.Domain.Model
{
    internal class LawnDescription
    {
        public string UpperRightCorner { get; set; }

        public List<MowerDescription> MowerDescriptions { get; set; }
    }
}