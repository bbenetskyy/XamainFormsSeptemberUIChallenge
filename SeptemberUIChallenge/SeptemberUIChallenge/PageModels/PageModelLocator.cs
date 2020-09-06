using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public class PageModelLocator
    {
        public WelcomePageModel WelcomePageModel => new WelcomePageModel(
            DependencyService.Get<ILoginService>(),
            DependencyService.Get<ISecureStorage>());
        public CardsPageModel CardsPageModel => new CardsPageModel(
            DependencyService.Get<IUserService>());
        public StatisticsPageModel StatisticsPageModel => new StatisticsPageModel();
        public FavouritesPageModel FavouritesPageModel => new FavouritesPageModel();
    }
}