using System.Threading.Tasks;

namespace SeptemberUIChallenge.Services
{
    public interface ILoginService
    {
        Task<string> Login(string email, string password);
        Task<string> Register(string email, string password);
    }
}