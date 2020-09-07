using System.Threading.Tasks;
using Refit;

namespace SeptemberUIChallenge.Data.Api
{
    public interface ILoginApi
    {
        [Post("/api/register")]
        Task<TokenResponse> Register([Body] LoginRequest request);
        
        [Post("/api/login")]
        Task<TokenResponse> Login([Body] LoginRequest request);
    }
}