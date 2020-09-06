using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;

namespace SeptemberUIChallenge.PageModels
{
    public class CardsPageModel
    {
        #region Fields

        #endregion Fields

        #region Constructor

        public CardsPageModel()
        {
            PageAppearingCommand = new AsyncCommand(ExecutePageAppearingCommand);
        }
        
        #endregion Constructor

        #region Properties

        public bool IsBusy { get; set; }

        #endregion Properties
        
        #region Commands
        
        public IAsyncCommand PageAppearingCommand { get; }
        
        #endregion Commands
        
        #region Public Methods
        
        
        
        #endregion Public Methods
        
        #region Private Methods

        private async Task ExecutePageAppearingCommand()
        {
            IsBusy = true;
            //todo load data from DB and show in UI
            IsBusy = false;
        }
        
        #endregion Private Methods
    }
}