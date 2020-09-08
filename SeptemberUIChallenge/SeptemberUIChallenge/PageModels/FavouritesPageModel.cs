using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Logger;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Services;

namespace SeptemberUIChallenge.PageModels
{
    public class FavouritesPageModel : BasePageModel
    {
        #region Fields
        
        private readonly IUserService _userService;

        #endregion Fields

        #region Constructor

        public FavouritesPageModel(IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<UserDetails>();
            PageAppearingCommand = new AsyncCommand(ExecutePageAppearingCommand);
        }

        #endregion Constructor

        #region Properties

        public ObservableCollection<UserDetails> Users { get; }

        #endregion Properties
        
        #region Commands
        
        public IAsyncCommand PageAppearingCommand { get; }
        
        #endregion Commands
        
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
                AlertService.ShowError(e.Message);
                Logger.LogError(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        #endregion Private Methods
    }
}