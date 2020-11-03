using Moq;
using Xunit;
using trivio.Clients;
using trivio.Models;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using static trivio.Program;
using Microsoft.Extensions.Options;

namespace trivio.Tests
{
    public class ClientTests {
        private readonly HttpClient _httpClient = new HttpClient();
        public readonly List<string> _countries = new List<string>() {"Iceland", "Denmark"};
        public readonly AppSettings _settings;
        public ClientTests() {
            _settings = new AppSettings() { Countries=_countries};
        }

        [Fact]
        public async void ShouldBeApplicableToCats() {
            Mock<ILogger<CatsClient>> logger = new Mock<ILogger<CatsClient>>();
            CatsClient client = new CatsClient(logger.Object, _httpClient);
            //Cats allow any non zero string
            Assert.True(client.IsApplicable("Abc"));
            Assert.False(client.IsApplicable(null));
        }
        [Fact]
        public async void ShouldBeApplicableToCountries() {
            Mock<ILogger<CountriesClient>> logger = new Mock<ILogger<CountriesClient>>();
            CountriesClient client = new CountriesClient(logger.Object, Options.Create(_settings), _httpClient);
            //Should only allow countries on the list
            Assert.True(client.IsApplicable(_countries[0]));
            Assert.False(client.IsApplicable("Abc"));
            Assert.False(client.IsApplicable(null));
        }
        [Fact]
        public async void ShouldBeApplicableToNumbers() {
            Mock<ILogger<NumbersClient>> logger = new Mock<ILogger<NumbersClient>>();
            NumbersClient client = new NumbersClient(logger.Object, _httpClient);
            //Should only accept words that are numbers
            Assert.True(client.IsApplicable("50"));
            Assert.False(client.IsApplicable("abc"));
            Assert.False(client.IsApplicable(null));
        }
    }
}