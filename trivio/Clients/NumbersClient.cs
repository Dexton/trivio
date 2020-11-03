using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace trivio.Clients
{
    public class NumbersClient : INumbersClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<NumbersClient> _logger;

        public NumbersClient(ILogger<NumbersClient> logger, HttpClient client) {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri("http://numbersapi.com/");
        }

        public bool IsApplicable(string word) {
            int testOut;
            return int.TryParse(word, out testOut);
        }

        public async Task<string> GetFact(string word)
        {
            HttpResponseMessage result = await _client.GetAsync(word);
            return await result.Content.ReadAsStringAsync();
        }
    }
}