using SeptemberUIChallenge.Data.Api;

namespace SeptemberUIChallenge.Models
{
    public class LoginModel : BaseUiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        //todo do we want to use it in login service?
        // public static implicit operator LoginRequest(LoginModel model) => new LoginRequest
        // {
        //     Email = model.Email,
        //     Password = model.Password
        // };
    }
}