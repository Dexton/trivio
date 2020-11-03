using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trivio.Services;
using trivio.Models;

namespace trivio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactsController : ControllerBase
    {
        
        private readonly ILogger<FactsController> _logger;
        private readonly IFactService _service;

        public FactsController(ILogger<FactsController> logger, IFactService service) {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/fact/{word}")]
        public async Task<Fact> Get([FromRoute] string word)
        {
            return await _service.GetFact(word);
        }
    }
}
