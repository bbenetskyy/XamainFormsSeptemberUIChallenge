using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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
        
        #endregion Fields

        #region Constructor

        public WelcomePageModel(
            ILoginService loginService,
            ISecureStorage storage)
        {
            _storage = storage;
            _loginService = loginService;
            _validator = new LoginValidator();
            LoginMode = Initial;
            LoginModel = new LoginModel();
            LoginCommand = new AsyncCommand(ExecuteLoginCommand);
            RegisterCommand = new AsyncCommand(ExecuteRegisterCommand);
            SwitchTypeCommand = new Command(ExecuteSwitchTypeCommand);
        }

        #endregion Constructor

        #region Properties

        public LoginModel LoginModel { get; set; }
        public bool  IsHighlyAppreciated { get; set; }
        public LoginMode LoginMode { get; set; } 

        #endregion Properties
        
        #region Commands

        public IAsyncCommand LoginCommand { get; }
        public IAsyncCommand RegisterCommand { get; }
        public ICommand SwitchTypeCommand { get; }
        
        #endregion Commands
        
        #region Private Methods
        
        private async Task ExecuteRegisterCommand()
        {
            if (LoginMode == Initial)
            {
                LoginMode = LoginMode.Register;
                return;
            }
            else if (LoginMode == LoginMode.Register)
            {
                if (await Register())
                {
                    IsHighlyAppreciated = true;
                    AlertService.ShowSuccess("Welcome, you are registered user now!!!", "Success", "Go and find someone", () =>
                      {
                          Application.Current.MainPage = new AppShell();
                      });
                }
            }
        }

        private Task<bool> Register() 
            => ValidateAndCallApi(() => _loginService.Register(LoginModel.Email, LoginModel.Password));

        private Task<bool> Login()        
            => ValidateAndCallApi(() => _loginService.Login(LoginModel.Email, LoginModel.Password));


        private async Task<bool> ValidateAndCallApi(Func<Task<string>> apiAction)
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
                var token = await apiAction();
                //in real app we might store this token and use in future requests, but our API we never need it
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
        
        private async Task ExecuteLoginCommand()
        {
            if (LoginMode == Initial)
            {
                LoginMode = LoginMode.Login;
                return;
            }
            else if (LoginMode == LoginMode.Login)
            {
                if (await Login())
                {
                    AlertService.ShowSuccess("Welcome back, glad to see you again!", "Success", "Go and find someone", () =>
                      {
                          Application.Current.MainPage = new AppShell();
                      });
                }
            }
        }
        
        private void ExecuteSwitchTypeCommand()
        {
            LoginMode = Initial;
        }
        
        #endregion Private Methods
    }
}
