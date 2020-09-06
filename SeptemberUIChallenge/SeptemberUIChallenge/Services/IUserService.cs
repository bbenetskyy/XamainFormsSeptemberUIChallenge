using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Services
{
    public interface IUserService
    {
        Task<List<UserDetails>> GetUserList(int page);
    }

    public class UserService : IUserService
    {
        private readonly IUserApi _userApi;

        public UserService(IUserApi userApi)
        {
            _userApi = userApi;
        }
        
        public async Task<List<UserDetails>> GetUserList(int page)
        {
            var usersResponse = await _userApi.GetUsers(page);
            return usersResponse.Data.Select(u=>(UserDetails)u).ToList();
        }
    }
}