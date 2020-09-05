using Newtonsoft.Json;
using Refit;

namespace SeptemberUIChallenge.Data.Api
{
    public class LoginRequest
    {
        [JsonProperty(PropertyName = "email")]
        [AliasAs("email")] 
        public string Email { get; set; }
        [AliasAs("password")] 
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}