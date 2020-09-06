using System.Collections.Generic;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Data.Infrastructure
{
    public interface IUserRepository
    {
        void AddFavouriteUser(UserDetails user);
        IEnumerable<UserDetails> GetAllFavouritesUsers();
    }
}