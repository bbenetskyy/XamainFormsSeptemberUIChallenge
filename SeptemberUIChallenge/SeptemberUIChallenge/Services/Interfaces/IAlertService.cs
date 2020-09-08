using System;

namespace SeptemberUIChallenge.Services
{
    public interface IAlertService
    {
        void ShowError(string message, string title = "Error", string okButtonText = "Ok", Action okButtonAction = null);
        void ShowWarning(string message, string title = "Warning", string okButtonText = "Ok", Action okButtonAction = null);
        void ShowSuccess(string message, string title = "Success", string okButtonText = "Ok", Action okButtonAction = null);
        void ShowConfirmation(string message, string title = "Error", string okButtonText = "Ok", Action okButtonAction = null, string cancelButtonText = "Cancel", Action cancelButtonAction = null);
    }
}