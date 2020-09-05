using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public class PageModelLocator
    {
        public WelcomePageModel WelcomePageModel => new WelcomePageModel(DependencyService.Get<ILoginService>());
        public CardsPageModel CardsPageModel => new CardsPageModel();
        public StatisticsPageModel StatisticsPageModel => new StatisticsPageModel();
        public FavouritesPageModel FavouritesPageModel => new FavouritesPageModel();
    }
}