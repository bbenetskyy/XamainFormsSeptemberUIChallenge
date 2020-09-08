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

        private const int AnimationSpeed = 500;

        private WelcomePageModel _viewModel;
        private double _initialLoginX;
        private double _initialLoginY;
        private double _initialRegisterX;
        private double _initialRegisterY;

        #endregion Fields

        #region Constructor

        public WelcomePage()
        {
            InitializeComponent();
            _viewModel = (WelcomePageModel)BindingContext;
            _viewModel.PropertyChanged += ViewModelPropertyChanged;
            StartLayout();
            _initialLoginX = LoginButton.X;
            _initialLoginY = LoginButton.Y;
            _initialRegisterX = RegisterButton.X;
            _initialRegisterY = RegisterButton.Y;
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
            BackLabel.TranslateTo(0, 30, 1);
            EmailEntry.TranslateTo(0, -60, 1);
            PasswordEntry.TranslateTo(0, -60, 1);
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
                    LoginButton.FadeTo(1, AnimationSpeed);
                    RegisterButton.FadeTo(1, AnimationSpeed);
                    BackLabel.FadeTo(0, AnimationSpeed);
                    EmailEntry.FadeTo(0, AnimationSpeed);
                    PasswordEntry.FadeTo(0, AnimationSpeed);
                    BackLabel.TranslateTo(0, 30, AnimationSpeed);
                    EmailEntry.TranslateTo(0, -60, AnimationSpeed);
                    PasswordEntry.TranslateTo(0, -60, AnimationSpeed);
                    _viewModel.LoginModel.Email = string.Empty;
                    _viewModel.LoginModel.Password = string.Empty;
                    RegisterButton.TranslateTo(_initialRegisterX, _initialRegisterY, AnimationSpeed);
                    LoginButton.TranslateTo(_initialLoginX, _initialLoginY, AnimationSpeed);
                    break;
                case LoginMode.Login:
                    BackLabel.TranslateTo(0, 0, AnimationSpeed);
                    EmailEntry.TranslateTo(0, 0, AnimationSpeed);
                    PasswordEntry.TranslateTo(0, 0, AnimationSpeed);
                    LoginButton.TranslateTo(20, LoginButton.Y + 30, AnimationSpeed);
                    RegisterButton.FadeTo(0, AnimationSpeed);
                    BackLabel.FadeTo(1, AnimationSpeed);
                    EmailEntry.FadeTo(1, AnimationSpeed);
                    PasswordEntry.FadeTo(1, AnimationSpeed);
                    break;
                case LoginMode.Register:
                    BackLabel.TranslateTo(0, 0, AnimationSpeed);
                    EmailEntry.TranslateTo(0, 0, AnimationSpeed);
                    PasswordEntry.TranslateTo(0, 0, AnimationSpeed);
                    RegisterButton.TranslateTo(-20, LoginButton.Y + 30, AnimationSpeed);
                    LoginButton.FadeTo(0, AnimationSpeed);
                    BackLabel.FadeTo(1, AnimationSpeed);
                    EmailEntry.FadeTo(1, AnimationSpeed);
                    PasswordEntry.FadeTo(1, AnimationSpeed);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loginMode));
            }
        }

        #endregion Private Methods

    }
}