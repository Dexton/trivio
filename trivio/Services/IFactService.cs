using System.Threading.Tasks;
using trivio.Models;

namespace trivio.Services
{
    public interface IFactService
    {
        Task<Fact> GetFact(string word);
    }
}