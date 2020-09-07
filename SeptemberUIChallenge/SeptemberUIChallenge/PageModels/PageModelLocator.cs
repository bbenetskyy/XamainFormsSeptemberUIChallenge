using SeptemberUIChallenge.Data.Logger;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public class PageModelLocator
    {
        public WelcomePageModel WelcomePageModel => new WelcomePageModel(
            DependencyService.Get<ILoginService>(),
            DependencyService.Get<ISecureStorage>(),
            DependencyService.Get<ILogger>());
        public CardsPageModel CardsPageModel => new CardsPageModel(
            DependencyService.Get<IUserService>(),
            DependencyService.Get<ILogger>());
        public StatisticsPageModel StatisticsPageModel => new StatisticsPageModel(
            DependencyService.Get<ILogger>());
        public FavouritesPageModel FavouritesPageModel => new FavouritesPageModel(
            DependencyService.Get<IUserService>(),
            DependencyService.Get<ILogger>());
    }
}