using SeptemberUIChallenge.Data.Api;

namespace SeptemberUIChallenge.Models
{
    public class LoginModel : BaseUiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}