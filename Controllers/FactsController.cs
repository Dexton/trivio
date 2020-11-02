using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace trivio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FactsController> _logger;

        public FactsController(ILogger<FactsController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public async Task<String> Index([FromRoute] string input)
        {
            return "Test";
        }

        [HttpGet("/fact/{input}")]
        public async Task<Fact> Get([FromRoute] string input)
        {
            var rng = new Random();
            return new Fact($"{input}");
        }
    }
}
