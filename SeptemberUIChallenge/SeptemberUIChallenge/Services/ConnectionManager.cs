using Xamarin.Essentials;
using Xamarin.Forms;

namespace SeptemberUIChallenge.Services
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly ICloseApplicationManager _applicationManager;
        private readonly IAlertService _alertService;

        public ConnectionManager(
            ICloseApplicationManager applicationManager,
            IAlertService alertService)
        {
            _applicationManager = applicationManager;
            _alertService = alertService;
        }
        
        public bool HasInternetAccess() => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public bool TerminateIfNoInternetAccess(bool forceTerminate = false)
        {
            if (HasInternetAccess()) return false;

            var okButtonPressed = false;

            if (forceTerminate)
            {
                _alertService.ShowWarning("This application cannot be used offline.", "No Internet!!!",
                    "Ok", () =>
                    {
                        _applicationManager.CloseApplication();
                    });
            }
            else
            {
                _alertService.ShowConfirmation("This application cannot be used offline.", "No Internet!!!",
                    "Ok", () =>
                    {
                        okButtonPressed = true;
                    }, "Close App", () =>
                    {
                        if (Device.RuntimePlatform == Device.iOS && okButtonPressed)
                            return;//this is bug https://github.com/kvandake/InteractiveAlert-Xamarin/issues/9
                        _applicationManager.CloseApplication();
                    });
            }

            return true;
        }
    }
}