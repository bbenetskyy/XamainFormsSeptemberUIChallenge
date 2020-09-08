using Foundation;
using Lottie.Forms.iOS.Renderers;
using SeptemberUIChallenge.iOS.Services;
using SeptemberUIChallenge.Services;
using UIKit;
using Xamarin.Forms;

namespace SeptemberUIChallenge.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.SetFlags("Shapes_Experimental", "Expander_Experimental");
            Xamarin.Forms.Forms.Init();
            Xamarin.Forms.FormsMaterial.Init();
            AnimationViewRenderer.Init();
            RegisterDependencies();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void RegisterDependencies()
        {
            DependencyService.Register<ICloseApplicationManager, CloseApplicationManager>();
        }
    }
}