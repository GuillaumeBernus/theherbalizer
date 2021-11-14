using PactNet;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Api.Tests.Pact.Consumer
{
    public class LawnConsumer : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort
        { get { return 1234; } }

        public string MockProviderServiceBaseUri
        { get { return String.Format("http://localhost:{0}", MockServerPort); } }

        public LawnConsumer()
        {
            PactBuilder = new PactBuilder(new PactConfig { PactDir = @"..\pacts", LogDir = @"c:\temp\logs" }); //Configures the PactDir and/or LogDir.

            PactBuilder
              .ServiceConsumer("Lawn Consumer")
              .HasPactWith("Lawn.API");

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            PactBuilder.Build();
        }
    }
}