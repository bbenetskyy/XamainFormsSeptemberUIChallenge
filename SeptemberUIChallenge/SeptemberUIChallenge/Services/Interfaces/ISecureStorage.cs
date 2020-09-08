using System.Threading.Tasks;

namespace SeptemberUIChallenge.Services
{
    public interface ISecureStorage
    {
        Task SetAsync(string key, string value);
    }
}