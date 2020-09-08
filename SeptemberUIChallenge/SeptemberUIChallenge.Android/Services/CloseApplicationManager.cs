using Android.App;
using Android.Support.V7.App;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.Android.Services
{
    public class CloseApplicationManager : ICloseApplicationManager
    {
        public void CloseApplication()
        {
            var activity = Forms.Context as AppCompatActivity;
            activity?.FinishAffinity();
        }
    }
}