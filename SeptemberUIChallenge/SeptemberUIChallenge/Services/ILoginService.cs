using System.Threading.Tasks;

namespace SeptemberUIChallenge.Services
{
    public interface ILoginService
    {
        Task Login(string email, string password);
        Task Register(string email, string password);
    }
}