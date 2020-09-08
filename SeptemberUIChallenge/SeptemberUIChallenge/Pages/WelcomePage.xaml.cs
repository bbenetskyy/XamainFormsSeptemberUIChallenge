using Xamarin.Forms;

namespace SeptemberUIChallenge.Pages
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            HoorayParticleCanvas.IsRunning = false;
        }
    }
}