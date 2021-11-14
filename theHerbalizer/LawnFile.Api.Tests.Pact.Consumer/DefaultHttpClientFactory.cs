using System;
using System.Net.Http;

namespace LawnFile.Api.Tests.Pact.Consumer
{
    /// <summary>
    /// Class LawnApiConsumerTests.
    /// Implements the <see cref="Xunit.IClassFixture{LawnFile.Api.Tests.Pact.Consumer.LawnConsumer}" />
    /// </summary>
    /// <seealso cref="Xunit.IClassFixture{LawnFile.Api.Tests.Pact.Consumer.LawnConsumer}" />
    public partial class LawnApiConsumerTests
    {
        /// <summary>
        /// Class DefaultHttpClientFactory.
        /// Implements the <see cref="System.Net.Http.IHttpClientFactory" />
        /// </summary>
        /// <seealso cref="System.Net.Http.IHttpClientFactory" />
        public class DefaultHttpClientFactory : IHttpClientFactory
        {
            /// <summary>
            /// The base address
            /// </summary>
            private readonly Uri _baseAddress;

            /// <summary>
            /// Initializes a new instance of the <see cref="DefaultHttpClientFactory"/> class.
            /// </summary>
            /// <param name="baseAddress">The base address.</param>
            public DefaultHttpClientFactory(string baseAddress)
            {
                _baseAddress = new Uri(baseAddress);
            }

            /// <summary>
            /// Creates and configures an <see cref="T:System.Net.Http.HttpClient" /> instance using the configuration that corresponds
            /// to the logical name specified by <paramref name="name" />.
            /// </summary>
            /// <param name="name">The logical name of the client to create.</param>
            /// <returns>A new <see cref="T:System.Net.Http.HttpClient" /> instance.</returns>
            /// <remarks><para>
            /// Each call to <see cref="M:System.Net.Http.IHttpClientFactory.CreateClient(System.String)" /> is guaranteed to return a new <see cref="T:System.Net.Http.HttpClient" />
            /// instance. It is generally not necessary to dispose of the <see cref="T:System.Net.Http.HttpClient" /> as the
            /// <see cref="T:System.Net.Http.IHttpClientFactory" /> tracks and disposes resources used by the <see cref="T:System.Net.Http.HttpClient" />.
            /// </para>
            /// <para>
            /// Callers are also free to mutate the returned <see cref="T:System.Net.Http.HttpClient" /> instance's public properties
            /// as desired.
            /// </para></remarks>
            public HttpClient CreateClient(string name)
            {
                var client = new HttpClient();
                client.BaseAddress = _baseAddress;
                return client;
            }
        }
    }
}