using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using trivio.Models;
using static trivio.Program;

namespace trivio.Clients
{
    public class CountriesClient : ICountriesClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<CountriesClient> _logger;
        private readonly AppSettings _settings;

        public CountriesClient(ILogger<CountriesClient> logger, IOptions<AppSettings> appSettings, HttpClient client) {
            _logger = logger;
            _client =  new HttpClient();
            _client = client;
            _client.BaseAddress = new System.Uri("https://restcountries.eu/rest/v2/name/");
            _settings = appSettings.Value;
        }

        public bool IsApplicable(string word) {
            return _settings.Countries.Contains(word);
        }
        public async Task<string> GetFact(string word)
        {
            HttpResponseMessage response = await _client.GetAsync(word);
            string json = await response.Content.ReadAsStringAsync();
            List<CountryResult> result = JsonConvert.DeserializeObject<List<CountryResult>>(json);
            return result[0].ToString();
        }
    }
}