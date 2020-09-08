using System;
using System.ComponentModel;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.PageModels;
using Xamarin.Forms;

namespace SeptemberUIChallenge.Pages
{
    public partial class WelcomePage : ContentPage
    {
        #region Fields

        private WelcomePageModel _viewModel;

        #endregion Fields

        #region Constructor
        
        public WelcomePage()
        {
            InitializeComponent();
            _viewModel = (WelcomePageModel)BindingContext;
            _viewModel.PropertyChanged += ViewModelPropertyChanged;
            StartLayout();
        }
        
        #endregion Constructor

        #region Protected Methods
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            HoorayParticleCanvas.IsRunning = false;
        }
        
        #endregion Protected Methods
        
        #region Private Methods

        private void StartLayout()
        {
            BackLabel.FadeTo(0, 1);
            EmailEntry.FadeTo(0, 1);
            PasswordEntry.FadeTo(0, 1);
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.LoginMode))
            {
                MakeTransformation(_viewModel.LoginMode);
            }
        }

        private void MakeTransformation(LoginMode loginMode)
        {
            switch (loginMode)
            {
                case LoginMode.Initial:
                    LoginButton.FadeTo(1, 500);
                    RegisterButton.FadeTo(1, 500);
                    BackLabel.FadeTo(0, 500);
                    EmailEntry.FadeTo(0, 500);
                    PasswordEntry.FadeTo(0, 500);
                    _viewModel.LoginModel.Email = string.Empty;
                    _viewModel.LoginModel.Password = string.Empty;
                    break;
                case LoginMode.Login:
                    RegisterButton.FadeTo(0, 500);
                    BackLabel.FadeTo(1, 500);
                    EmailEntry.FadeTo(1, 500);
                    PasswordEntry.FadeTo(1, 500);
                    break;
                case LoginMode.Register:
                    LoginButton.FadeTo(0, 500);
                    BackLabel.FadeTo(1, 500);
                    EmailEntry.FadeTo(1, 500);
                    PasswordEntry.FadeTo(1, 500);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loginMode));
            }
        }
        
        #endregion Private Methods

    }
}