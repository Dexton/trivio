using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace trivio.Clients
{
    // Dummy interface to simplify DI
    // DI does not like multiple implementations of the same interface
    public interface INumbersClient : IFactsClient {}
}