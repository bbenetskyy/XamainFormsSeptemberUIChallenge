using SeptemberUIChallenge.Pages;
using Xamarin.Forms;

namespace SeptemberUIChallenge
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("welcome", typeof(WelcomePage));
            Routing.RegisterRoute("cards", typeof(CardsPage));
            Routing.RegisterRoute("favourites", typeof(FavouritesPage));
            Routing.RegisterRoute("statistics", typeof(StatisticsPage));
        }
    }
}