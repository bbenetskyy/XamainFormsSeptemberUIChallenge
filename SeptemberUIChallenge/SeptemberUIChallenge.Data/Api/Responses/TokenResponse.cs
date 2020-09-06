using Newtonsoft.Json;

namespace SeptemberUIChallenge.Data.Api
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}