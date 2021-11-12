using LawnFile.Domain.Extensions;
using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LawnFile.Domain.Handler
{
    public class LawnFileHandler : ILawnFileHandler
    {
        public LawnFileHandler()
        {
        }

        public async Task<Lawn> HandleAsync(string filePath)
        {
            using StreamReader srIn = new StreamReader(filePath, true);

            if (srIn.EndOfStream)
            {
                throw new Exception("Empty file");
            }

            var lawnSize = await srIn.ReadLineAsync().ConfigureAwait(false);

            if (!lawnSize.IsLawnDescription())
            {
                throw new Exception("First Line is not a lawn description");
            }

            var mowerDescriptions = new List<MowerDescription>();
            while (!srIn.EndOfStream)
            {
                var mowerDescription = await srIn.ExtractMowerDescriptionAsync().ConfigureAwait(false);

                if (!mowerDescription.Check())
                {
                    throw new Exception("Wrong mower description");
                }
                mowerDescriptions.Add(mowerDescription);
            }

            var lawnDescription = new LawnDescription
            {
                UpperRightCorner = lawnSize,
                MowerDescriptions = mowerDescriptions
            };

            return Lawn.FromLawnDescription(lawnDescription);
        }
    }
}