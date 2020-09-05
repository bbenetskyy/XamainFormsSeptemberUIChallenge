using Realms;

namespace SeptemberUIChallenge.Data.Infrastructure
{
    public interface IDatabaseProvider
    {
        Realm GetInstance();
    }
}