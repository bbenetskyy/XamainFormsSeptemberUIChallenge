using System.Threading.Tasks;
using Refit;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Data.Api
{
    public interface ILoginApi
    {
        [Post("/api/register")]
        Task Register([Body] LoginRequest request);
        
        [Post("/api/login")]
        Task Login([Body] LoginRequest request);
    }
}