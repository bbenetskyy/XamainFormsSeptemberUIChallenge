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
        
        public Task Login(string email, string password)
        {
            var requestModel = new LoginRequest
            {
                Email = email,
                Password = password
            };
            return _loginApi.Login(requestModel);
        }

        public Task Register(string email, string password)
        {
            var requestModel = new LoginRequest
            {
                Email = email,
                Password = password
            };
            return _loginApi.Register(requestModel);
        }
    }
}