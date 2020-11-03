using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using trivio.Models;

namespace trivio.Clients
{
    public class CatsClient : ICatsClient
    {
        private readonly ILogger<CatsClient> _logger;
        private HttpClient _client;

        public CatsClient(ILogger<CatsClient> logger, HttpClient client) {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new System.Uri("https://catfact.ninja/");
        }

        public bool IsApplicable(string word)
        {
            return !(string.IsNullOrEmpty(word));
        }
        
        public async Task<string> GetFact(string word)
        {
            HttpResponseMessage response = await _client.GetAsync("fact/");
            string json = await response.Content.ReadAsStringAsync();
            CatResult result = JsonSerializer.Deserialize<CatResult>(json);
            return result.fact;
        }

    }
}