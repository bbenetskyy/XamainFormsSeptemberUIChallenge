using Refit;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Data.Infrastructure;
using SeptemberUIChallenge.Data.Logger;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge
{
    public static class IoC
    {
        public static void RegisterTypes()
        {
            // That's why I low IoC in MVVMCross :P
            DependencyService.RegisterSingleton<ILogger>(new LogDebugManager());
            DependencyService.RegisterSingleton<IDatabaseProvider>(new InMemoryDatabaseProvider(
                DependencyService.Get<ILogger>()));
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