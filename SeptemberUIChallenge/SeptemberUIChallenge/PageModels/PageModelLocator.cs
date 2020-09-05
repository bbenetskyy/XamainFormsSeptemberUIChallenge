namespace SeptemberUIChallenge.PageModels
{
    public class PageModelLocator
    {
        public WelcomePageModel WelcomePageModel => new WelcomePageModel();
        public CardsPageModel CardsPageModel => new CardsPageModel();
        public StatisticsPageModel StatisticsPageModel => new StatisticsPageModel();
        public FavouritesPageModel FavouritesPageModel => new FavouritesPageModel();
    }
}