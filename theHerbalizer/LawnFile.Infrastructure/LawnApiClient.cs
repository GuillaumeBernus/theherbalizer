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
    /// <summary>
    /// Class LawnApiClient.
    /// Implements the <see cref="LawnFile.Domain.Interface.ILawnApiClient" />
    /// </summary>
    /// <seealso cref="LawnFile.Domain.Interface.ILawnApiClient" />
    public class LawnApiClient : ILawnApiClient
    {
        /// <summary>
        /// The http client factory
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// The json serializer options
        /// </summary>
        private static readonly JsonSerializerOptions _jsonSerializerOptions= GetJsonSerializerOptions();


        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiClient"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <exception cref="System.ArgumentNullException">httpClientFactory</exception>
        public LawnApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));

        }

        /// <summary>
        /// Gets the json serializer options.
        /// </summary>
        /// <returns>JsonSerializerOptions.</returns>
        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            return jsonSerializerOptions;
        }

        /// <summary>
        /// Treat lawn description as an asynchronous operation.
        /// </summary>
        /// <param name="lawn">The lawn.</param>
        /// <returns>A Task&lt;List`1&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception"></exception>
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
                    res = JsonSerializer.Deserialize<List<MowerPosition>>(responseContent, _jsonSerializerOptions);
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
