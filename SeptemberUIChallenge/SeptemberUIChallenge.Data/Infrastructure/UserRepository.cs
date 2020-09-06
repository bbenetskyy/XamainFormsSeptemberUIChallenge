using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using Realms.Exceptions;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Data.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        protected Realm Realm { get; }
        
        public UserRepository(IDatabaseProvider databaseProvider)
        {
            Realm = databaseProvider.GetInstance();
        }
        
        public void AddFavouriteUser(UserDetails user)
        {
            try
            {
                Realm.Write(() => Realm.Add(user));
            }
            catch (RealmDuplicatePrimaryKeyValueException)
            {
                //todo use resource file
                throw new ArgumentException($"User Already Exist {user.Email}");
            }
        }

        public IEnumerable<UserDetails> GetAllFavouritesUsers()
        {
            return Realm.All<UserDetails>().OrderByDescending(x=>x.Email);
        }
    }
}