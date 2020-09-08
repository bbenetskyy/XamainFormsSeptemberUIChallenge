using System;
using InteractiveAlert;
using static InteractiveAlert.InteractiveAlertStyle;

namespace SeptemberUIChallenge.Services
{
    public class AlertService : IAlertService
    {
        private readonly IInteractiveAlerts _interactiveAlerts;

        public AlertService(IInteractiveAlerts interactiveAlerts)
        {
            _interactiveAlerts = interactiveAlerts;
        }
        
        public void ShowError(string message, string title = "Error", string okButtonText = "Ok", Action okButtonAction = null)
        {
            Show(message,title,okButtonText,okButtonAction,Error);
        }
        
        public void ShowWarning(string message, string title = "Warning", string okButtonText = "Ok", Action okButtonAction = null)
        {
            Show(message,title,okButtonText,okButtonAction,Warning);
        }
        
        public void ShowSuccess(string message, string title = "Success", string okButtonText = "Ok", Action okButtonAction = null)
        {
            Show(message,title,okButtonText,okButtonAction,Success);
        }
        
        public void ShowConfirmation(string message, string title = "Error", string okButtonText = "Ok", Action okButtonAction = null, string cancelButtonText = "Cancel", Action cancelButtonAction = null)
        {
            var alertConfig = new InteractiveAlertConfig
            {
                OkButton = new InteractiveActionButton
                {
                    Title = okButtonText,
                    Action = okButtonAction
                },
                CancelButton = new InteractiveActionButton
                {
                    Title = cancelButtonText,
                    Action = cancelButtonAction
                },
                Title = title,
                Message = message,
                Style = Wait,
                IsCancellable = true
            };
            _interactiveAlerts.ShowAlert(alertConfig);
        }

        private void Show(string message, string title, string okButtonText, Action okButtonAction, InteractiveAlertStyle style)
        {
            var alertConfig = new InteractiveAlertConfig
            {
                OkButton = new InteractiveActionButton
                {
                    Title = okButtonText,
                    Action = okButtonAction
                },
                Title = title,
                Message = message,
                Style = style,
                IsCancellable = true
            };
            _interactiveAlerts.ShowAlert(alertConfig);
        }
    }
}