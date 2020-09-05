using Newtonsoft.Json;

namespace SeptemberUIChallenge.Data.Api
{
    public abstract class UserDetailsResponse
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }
    }
}