using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LawnFile.Infrastructure
{
    public class LawnApiClient : ILawnApiClient
    {
        /// <summary>
        /// The http client factory
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;



        public LawnApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<List<MowerPosition>> TreatLawnDescriptionAsync(Lawn lawn)
        {

            var res = new List<MowerPosition>();

            HttpClient httpClient = _httpClientFactory
                    .CreateClient(Constants.LawnApiClientName);

            Uri uri = new Uri($"{httpClient.BaseAddress}{Constants.LawnApiRoute}");
            string serialized = JsonSerializer.Serialize(lawn);
            var requestContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, requestContent).ConfigureAwait(false);

            if (httpResponseMessage != null && httpResponseMessage.IsSuccessStatusCode)
            {
                string responseContent = (httpResponseMessage.Content != null) ? await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) : string.Empty;

                if (!string.IsNullOrEmpty(responseContent))
                {


                    var enumConverter = new JsonStringEnumConverter();
                    JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    options.Converters.Add(enumConverter);


                    res = JsonSerializer.Deserialize<List<MowerPosition>>(responseContent,options);
                }
            }
            else
            {
                throw new Exception(httpResponseMessage?.StatusCode.ToString());
            }
            return res;
        }
    }
}
