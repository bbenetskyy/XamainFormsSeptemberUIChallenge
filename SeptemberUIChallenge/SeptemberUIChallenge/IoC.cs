using Refit;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Data.Infrastructure;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge
{
    public static class IoC
    {
        public static void RegisterTypes()
        {
            DependencyService.RegisterSingleton<IDatabaseProvider>(new InMemoryDatabaseProvider());
            DependencyService.RegisterSingleton<ISecureStorage>(new SecureStorage());
            DependencyService.RegisterSingleton<ILoginApi>(RestService.For<ILoginApi>("https://reqres.in"));
            DependencyService.RegisterSingleton<IUserApi>(RestService.For<IUserApi>("https://reqres.in"));
            DependencyService.RegisterSingleton<ILoginService>(new LoginService(
                DependencyService.Get<ILoginApi>()));
            DependencyService.RegisterSingleton<IUserRepository>(new UserRepository(
                DependencyService.Get<IDatabaseProvider>()));
            DependencyService.RegisterSingleton<IUserService>(new UserService(
                DependencyService.Get<IUserApi>(),
                DependencyService.Get<IUserRepository>()));
        }
    }
}