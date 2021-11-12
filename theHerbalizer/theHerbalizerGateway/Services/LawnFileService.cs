using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace theHerbalizerGateway.Services
{
    class LawnFileService:ILawnFileService
    {
        HttpClient _apiClient;

        public LawnFileService(HttpClient httpClient)
        {
            _apiClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<Stream> TreatFileAsync(IFormFile formFile)
        {

            string lawnFileDescription = await GetLawnDescriptionAsync(formFile).ConfigureAwait(false);

            return null;
        }

        private async Task<string> GetLawnDescriptionAsync (IFormFile formFile)
        {
            var stream = formFile.OpenReadStream();

            var response = await _apiClient.PostAsync("http://localhost:60668/lawndescriptionfile", new StreamContent(stream)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return  await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            }
            return "";
        }

    }
}
