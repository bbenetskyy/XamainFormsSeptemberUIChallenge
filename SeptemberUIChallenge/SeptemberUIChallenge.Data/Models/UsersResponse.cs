using System.Collections.Generic;

namespace SeptemberUIChallenge.Data.Models
{
    public class UsersResponse
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<UserDto> Data { get; set; }
    }
}