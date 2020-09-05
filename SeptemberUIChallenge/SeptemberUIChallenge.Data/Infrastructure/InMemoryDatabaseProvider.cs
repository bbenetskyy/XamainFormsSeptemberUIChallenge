using System;
using System.Diagnostics;
using Realms;

namespace SeptemberUIChallenge.Data.Infrastructure
{
    public class InMemoryDatabaseProvider : IDatabaseProvider
    {
        public Realm GetInstance()
        {
            try
            {
                var config = new InMemoryConfiguration(Guid.NewGuid().ToString());
                return Realm.GetInstance(config);
            }
            catch (Exception e)
            {
                //in real app it should be replaced with logger
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}