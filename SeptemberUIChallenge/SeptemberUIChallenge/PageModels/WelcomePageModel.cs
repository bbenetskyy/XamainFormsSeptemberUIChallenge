using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;
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
            ISecureStorage storage,
            ILogger logger) : base(logger)
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

            await MakeRegistration();
        }

        private async Task MakeRegistration()
        {
            var result = await _validator.ValidateAsync(LoginModel);
            if (!result.IsValid)
            {
                //todo add validation Error to UI
                return;
            }
            
            try
            {
               var token =  await (_loginMode switch
                {
                    Register => _loginService.Register(LoginModel.Email,LoginModel.Password),
                    Login => _loginService.Login(LoginModel.Email,LoginModel.Password),
                    _ => throw new ArgumentOutOfRangeException(nameof(_loginMode))
                });
               //in real app we might store this token and use in future requests, but our API never need it
               //await _storage.SetAsync(nameof(token),token);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception e)
            {
               Logger.LogError(e);
            }
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
            
            await MakeRegistration();
        }
        
        private async Task ExecuteSwitchTypeCommand()
        {
            _loginMode = Undefined;
            MakeTransformation();
        }
        
        #endregion Private Methods
    }
}
