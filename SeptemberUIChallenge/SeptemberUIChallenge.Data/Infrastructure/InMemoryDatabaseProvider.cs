using System;
using System.Diagnostics;
using Realms;
using SeptemberUIChallenge.Data.Logger;

namespace SeptemberUIChallenge.Data.Infrastructure
{
    public class InMemoryDatabaseProvider : IDatabaseProvider
    {
        private readonly ILogger _logger;

        public InMemoryDatabaseProvider(ILogger logger)
        {
            _logger = logger;
        }
        
        public Realm GetInstance()
        {
            try
            {
                var config = new InMemoryConfiguration("9245fe4a-d402-451c-b9ed-9c1a04247482");
                return Realm.GetInstance(config);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                throw;
            }
        }
    }
}