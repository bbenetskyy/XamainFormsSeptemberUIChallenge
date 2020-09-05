using System.Collections.Generic;

namespace SeptemberUIChallenge.Data.Api
{
    public class UsersResponse
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<UserDetailsResponse> Data { get; set; }
    }
}