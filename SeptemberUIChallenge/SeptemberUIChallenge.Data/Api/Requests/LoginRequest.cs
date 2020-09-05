using Newtonsoft.Json;
using Refit;

namespace SeptemberUIChallenge.Data.Api
{
    public class LoginRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}