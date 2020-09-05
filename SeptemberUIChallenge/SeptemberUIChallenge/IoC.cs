using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Infrastructure;
using Xamarin.Forms;

namespace SeptemberUIChallenge
{
    public static class IoC
    {
        public static void RegisterTypes()
        {
            DependencyService.Register<InMemoryDatabaseProvider>();
        }
    }
}