using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Services;

namespace SeptemberUIChallenge.PageModels
{
    public class FavouritesPageModel : BasePageModel
    {
        private readonly IUserService _userService;

        #region Fields

        #endregion Fields

        #region Constructor

        public FavouritesPageModel(
            IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<UserDetails>();
            PageAppearingCommand = new AsyncCommand(ExecutePageAppearingCommand);
        }

        #endregion Constructor

        #region Properties

        public bool IsBusy { get; set; }
        public ObservableCollection<UserDetails> Users { get; }

        #endregion Properties
        
        #region Commands
        
        public IAsyncCommand PageAppearingCommand { get; }

        
        #endregion Commands
        
        #region Public Methods
        
        
        #endregion Public Methods
        
        #region Private Methods
        
        private async Task ExecutePageAppearingCommand()
        {
            try
            {
                IsBusy = true;
                Users.Clear();
                var users = await _userService.GetAllFavouritesUsers();
                users.ForEach(Users.Add);
            }
            catch (Exception e)
            {
                //in real app it should be replaced with logger
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        #endregion Private Methods

    }
}