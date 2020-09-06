using System.Threading.Tasks;
using SeptemberUIChallenge.Data.Api;

namespace SeptemberUIChallenge.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginApi _loginApi;

        public LoginService(ILoginApi loginApi)
        {
            _loginApi = loginApi;
        }
        
        public async Task<string> Login(string email, string password)
        {
            var requestModel = new LoginRequest
            {
                Email = email,
                Password = password
            };
            return (await _loginApi.Login(requestModel)).Token;
        }

        public async Task<string> Register(string email, string password)
        {
            var requestModel = new LoginRequest
            {
                Email = email,
                Password = password
            };
            return (await _loginApi.Register(requestModel)).Token;
        }
    }
}