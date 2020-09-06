using System.Collections.Generic;
using System.Threading.Tasks;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Services
{
    public interface IUserService
    {
        Task<List<UserDetails>> GetUserList(int page);
        void SaveFavouriteUser(UserDetails user);
    }
}