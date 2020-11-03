using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using trivio.Clients;
using trivio.Models;
using static trivio.Program;

namespace trivio.Services
{
    public class FactService : IFactService
    {
        private readonly ILogger<FactService> _logger;
        private readonly IEnumerable<IFactsClient> _clients;
        private readonly AppSettings _settings;

        public FactService(ICatsClient cats, ICountriesClient countries, INumbersClient numbers, IOptions<AppSettings> settings) {
            _clients = new List<IFactsClient>() { numbers, countries, cats};
            _settings = settings.Value;
        }

        private async Task<string> RouteToClient(string word) {
            foreach (IFactsClient client in _clients) {
                if(client.IsApplicable(word)) {
                    return await client.GetFact(word);
                }
            }
            return _settings.NotFoundMessage;
        }

        public async Task<Fact> GetFact(string word)
        {
            return new Fact(await RouteToClient(word));
        }
    }
}