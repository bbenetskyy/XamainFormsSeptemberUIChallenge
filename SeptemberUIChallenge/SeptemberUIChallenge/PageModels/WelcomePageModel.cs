using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Models;
using Xamarin.Forms;
using static SeptemberUIChallenge.Data.Models.LoginMode;

namespace SeptemberUIChallenge.PageModels
{
    public class WelcomePageModel : BasePageModel
    {
        #region Fields

        private LoginMode _loginMode;

        #endregion Fields

        #region Constructor

        public WelcomePageModel()
        {
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

            //todo RegisterUser();
            Application.Current.MainPage = new AppShell();
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
            //todo LoginUser();
            Application.Current.MainPage = new AppShell();
        }
        
        private async Task ExecuteSwitchTypeCommand()
        {
            _loginMode = Undefined;
            MakeTransformation();
        }
        
        #endregion Private Methods
    }
}



/*


        #region Fields

        #endregion Fields

        #region Constructor


        #endregion Constructor

        #region Properties

        

        #endregion Properties
        
        #region Commands
        
        #endregion Commands
        
        #region Public Methods
        
        
        #endregion Public Methods
        
        #region Private Methods
        
        
        #endregion Private Methods

*/