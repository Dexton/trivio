using System.Threading.Tasks;

namespace trivio.Clients
{
    public interface IFactsClient
    {
        Task<string> GetFact(string word);
        bool IsApplicable(string word);

    }
}