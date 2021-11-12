using LawnFile.Domain.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LawnFile.Domain.Extensions
{
    internal static class StreamReaderExtensions
    {
        public static async Task<MowerDescription> ExtractMowerDescriptionAsync(this StreamReader sr)
        {
            var mowerDescription = new MowerDescription();
            mowerDescription.StartPosition = await sr.ReadLineAsync();
            if (sr.EndOfStream)
            {
                throw new Exception("No SecondLine");
            }
            mowerDescription.Route = sr.ReadLine();
            return mowerDescription;
        }
    }
}