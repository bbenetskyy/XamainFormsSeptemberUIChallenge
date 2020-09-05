using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Services;
using SeptemberUIChallenge.Validators;
using Xamarin.Forms;
using static SeptemberUIChallenge.Data.Models.LoginMode;

namespace SeptemberUIChallenge.PageModels
{
    public class WelcomePageModel : BasePageModel
    {
        #region Fields
        
        private readonly ILoginService _loginService;
        private readonly EmailValidator _validator;

        private LoginMode _loginMode;

        #endregion Fields

        #region Constructor

        public WelcomePageModel(ILoginService loginService)
        {
            _loginService = loginService;
            _validator = new EmailValidator();
            _loginMode = Undefined;
            
            LoginCommand = new AsyncCommand(ExecuteLoginCommand);
            RegisterCommand = new AsyncCommand(ExecuteRegisterCommand);
            SwitchTypeCommand = new AsyncCommand(ExecuteSwitchTypeCommand);
        }

        #endregion Constructor

        #region Properties

        public string Email { get; set; }
        public string Password { get; set; }

        #endregion Properties
        
        #region Commands

        public IAsyncCommand LoginCommand { get; }
        public IAsyncCommand RegisterCommand { get; }
        
        public IAsyncCommand SwitchTypeCommand { get; }
        
        #endregion Commands
        
        #region Public Methods
        
        
        #endregion Public Methods
        
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
            //todo add password validator later
            //todo add it as a new type?
            var result = await _validator.ValidateAsync(Email);
            if (!result.IsValid)
            {
                //todo add validation Error to UI
                return;
            }
            
            try
            {
                await (_loginMode switch
                {
                    Register => _loginService.Register(Email,Password),
                    Login => _loginService.Login(Email,Password),
                    _ => throw new ArgumentOutOfRangeException(nameof(_loginMode))
                });
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception e)
            {
                //in real app it should be replaced with logger
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
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
