using LawnFile.Domain.Model;
using LawnFile.Infrastructure;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace LawnFile.Api.Tests.Pact.Consumer
{
    /// <summary>
    /// Class LawnApiConsumerTests.
    /// Implements the <see cref="Xunit.IClassFixture{LawnFile.Api.Tests.Pact.Consumer.LawnConsumer}" />
    /// </summary>
    /// <seealso cref="Xunit.IClassFixture{LawnFile.Api.Tests.Pact.Consumer.LawnConsumer}" />
    public partial class LawnApiConsumerTests : IClassFixture<LawnConsumer>
    {
        /// <summary>
        /// The mock provider service
        /// </summary>
        private readonly IMockProviderService _mockProviderService;

        /// <summary>
        /// The mock provider service base URI
        /// </summary>
        private readonly string _mockProviderServiceBaseUri;

        /// <summary>
        /// The provider service request body
        /// </summary>
        private static readonly dynamic _providerServiceRequestBody = new
        {
            UpperRigthCorner = new
            {
                X = 5,
                Y = 5
            },
            Mowers = new[]
            {
                new {
                    StartPosition= new
                    {
                        Coordinates= new {
                            X= 0,
                            Y= 0
                        },
                        Orientation= "N"
                    },
                    Route= "FF"
                }
            }
        };

        /// <summary>
        /// The provider service response body
        /// </summary>
        private static readonly dynamic _providerServiceResponseBody = new[]
                    {
                        new
                        {
                            Coordinates = new
                            {
                                X = 0,
                                Y = 2
                            },
                            Orientation = "N"
                        }
                    };

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnApiConsumerTests" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public LawnApiConsumerTests(LawnConsumer data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions();
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

        /// <summary>
        /// Defines the test method GetMowerPositionsAsync_WhenTheLawnIsValid_ReturnsTheMowerPositionsAsync.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetMowerPositionsAsync_WhenTheLawnIsValid_ReturnsTheMowerPositionsAsync()
        {
            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            string sLawn = await File.ReadAllTextAsync(@"./json/Lawn_Request.json")
                   .ConfigureAwait(false);

            Lawn requestedLawn = JsonSerializer.Deserialize<Lawn>(sLawn, jsonSerializerOptions);

            //Arrange
            _mockProviderService
              .Given("Get the Mower positions on this lawn")
              .UponReceiving("A POST request to mow this lawn")
              .With(new ProviderServiceRequest
              {
                  Method = HttpVerb.Post,
                  Path = "/lawn",
                  Headers = new Dictionary<string, object>
                {
                    {"Content-Type", "application/json; charset=utf-8"}
                }
                              ,
                  Body = _providerServiceRequestBody
              })
              .WillRespondWith(new ProviderServiceResponse
              {
                  Status = 200,
                  Headers = new Dictionary<string, object>
                {
                    { "Content-Type", "application/json; charset=utf-8" }
                },
                  Body = _providerServiceResponseBody
              });

            //Act

            DefaultHttpClientFactory httpClientFactory = new DefaultHttpClientFactory(_mockProviderServiceBaseUri);

            var consumer = new LawnApiClient(httpClientFactory);
            var result = await consumer.GetMowerPositionsAsync(requestedLawn).ConfigureAwait(false);

            //Assert
            Assert.Equal(1, result.Count);

            _mockProviderService.VerifyInteractions();
        }
    }
}