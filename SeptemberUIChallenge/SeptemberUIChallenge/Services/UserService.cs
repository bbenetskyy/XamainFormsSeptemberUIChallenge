using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Data.Infrastructure;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly IUserApi _userApi;
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserApi userApi,
            IUserRepository userRepository)
        {
            _userApi = userApi;
            _userRepository = userRepository;
        }
        
        public async Task<List<UserDetails>> GetUserList(int page)
        {
            var usersResponse = await _userApi.GetUsers(page);
            return usersResponse.Data.Select(u=>(UserDetails)u).ToList();
        }

        public void SaveFavouriteUser(UserDetails user)
        {
            if(user == null)
                return;
            _userRepository.AddFavouriteUser(user);
        }
    }
}