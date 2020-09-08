using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using InteractiveAlert;
using Lottie.Forms.Droid;

namespace SeptemberUIChallenge.Android
{
    [Activity(Label = "SeptemberUIChallenge", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.SetFlags("Shapes_Experimental", "Expander_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            AnimationViewRenderer.Init();
            InteractiveAlerts.Init(() => (AppCompatActivity) Xamarin.Forms.Forms.Context);
            LoadApplication(new App());
        }
    }
}