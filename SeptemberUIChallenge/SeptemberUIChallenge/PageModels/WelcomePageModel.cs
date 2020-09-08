using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Data.Logger;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Models;
using SeptemberUIChallenge.Services;
using SeptemberUIChallenge.Validators;
using Xamarin.Essentials;
using Xamarin.Forms;
using static SeptemberUIChallenge.Data.Models.LoginMode;

namespace SeptemberUIChallenge.PageModels
{
    public class WelcomePageModel : BasePageModel
    {
        #region Fields
        
        private readonly ILoginService _loginService;
        private readonly LoginValidator _validator;
        private readonly ISecureStorage _storage;

        private LoginMode _loginMode;

        #endregion Fields

        #region Constructor

        public WelcomePageModel(
            ILoginService loginService,
            ISecureStorage storage)
        {
            _storage = storage;
            _loginService = loginService;
            _validator = new LoginValidator();
            _loginMode = Undefined;
            LoginModel = new LoginModel();
            LoginCommand = new AsyncCommand(ExecuteLoginCommand);
            RegisterCommand = new AsyncCommand(ExecuteRegisterCommand);
            SwitchTypeCommand = new AsyncCommand(ExecuteSwitchTypeCommand);
        }

        #endregion Constructor

        #region Properties

        public LoginModel LoginModel { get; set; }
        public bool  IsHighlyAppreciated { get; set; }

        #endregion Properties
        
        #region Commands

        public IAsyncCommand LoginCommand { get; }
        public IAsyncCommand RegisterCommand { get; }
        public IAsyncCommand SwitchTypeCommand { get; }
        
        #endregion Commands
        
        #region Private Methods
        
        private async Task ExecuteRegisterCommand()
        {
            if (_loginMode == Undefined)
            {
                _loginMode = Register;
                MakeTransformation();
                return;
            }

            if (await MakeRegistration())
            {
                IsHighlyAppreciated = true;
                AlertService.ShowSuccess("Welcome, you are registered user now!!!","","Go and find someone", () =>
                {
                    Application.Current.MainPage = new AppShell();
                });
            }
        }

        private async Task<bool> MakeRegistration()
        {
            var result = await _validator.ValidateAsync(LoginModel);
            if (!result.IsValid)
            {
                AlertService.ShowError(result.Errors.First().ErrorMessage,"Validation Error");
                return false;
            }

            if (ConnectionManager.TerminateIfNoInternetAccess()) return false;

            try
            {
                IsBusy = true;
                var token = await (_loginMode switch
                {
                    Register => _loginService.Register(LoginModel.Email, LoginModel.Password),
                    Login => _loginService.Login(LoginModel.Email, LoginModel.Password),
                    _ => throw new ArgumentOutOfRangeException(nameof(_loginMode))
                });
                //in real app we might store this token and use in future requests, but our API never need it
                //await _storage.SetAsync(nameof(token),token);
                return true;
            }
            catch (ApiException apiException)
            {
                AlertService.ShowError(apiException.GetContentErrorString());
                Logger.LogError(apiException);
            }
            catch (Exception e)
            {
                AlertService.ShowError(e.Message);
                Logger.LogError(e);
            }
            finally
            {
                IsBusy = false;
            }
            return false;
        }

        private void MakeTransformation()
        {
            //todo make transformations
        }

        private async Task ExecuteLoginCommand()
        {
            if (_loginMode == Undefined)
            {
                _loginMode = Login;
                MakeTransformation();
                return;
            }
            
            if (await MakeRegistration())
            {
                AlertService.ShowSuccess("Welcome back, glad to see you again!","","Go and find someone", () =>
                {
                    Application.Current.MainPage = new AppShell();
                });
            }
        }
        
        private async Task ExecuteSwitchTypeCommand()
        {
            _loginMode = Undefined;
            MakeTransformation();
        }
        
        #endregion Private Methods
    }
}
