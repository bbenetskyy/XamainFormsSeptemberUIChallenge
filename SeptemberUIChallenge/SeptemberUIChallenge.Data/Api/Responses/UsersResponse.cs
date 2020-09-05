using System.Collections.Generic;
using Newtonsoft.Json;

namespace SeptemberUIChallenge.Data.Api
{
    public class UsersResponse
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        
        [JsonProperty(PropertyName = "data")]
        public List<UserDetailsResponse> Data { get; set; }
    }
}