using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MLToolkit.Forms.SwipeCardView.Core;
using Refit;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Api;
using SeptemberUIChallenge.Data.Logger;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public class CardsPageModel : BasePageModel
    {
        #region Fields
        
        private readonly IUserService _userService;

        #endregion Fields

        #region Constructor

        public CardsPageModel(IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<UserDetails>();
            PageAppearingCommand = new AsyncCommand(ExecutePageAppearingCommand);
            CardDraggingCommand = new Command<DraggingCardEventArgs>(ExecuteCardDraggingCommand);
        }

        #endregion Constructor

        #region Properties

        public ObservableCollection<UserDetails> Users { get; }

        #endregion Properties
        
        #region Commands
        
        public IAsyncCommand PageAppearingCommand { get; }
        public Command<DraggingCardEventArgs> CardDraggingCommand { get; }
        
        #endregion Commands
        
        #region Private Methods

        private void ExecuteCardDraggingCommand(DraggingCardEventArgs args)
        {
            try
            {
                if (args.Direction == SwipeCardDirection.Right)
                {
                    _userService.SaveFavouriteUser(args.Item as UserDetails);
                }
            }
            catch (Exception e)
            {
                AlertService.ShowError(e.Message);
                Logger.LogError(e);
            }
        }

        private async Task ExecutePageAppearingCommand()
        {
            if (ConnectionManager.TerminateIfNoInternetAccess(true)) return;
            
            try
            {
                IsBusy = true;
                Users.Clear();
                var users = await _userService.GetUserList();
                users.ForEach(Users.Add);
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
        }

        #endregion Private Methods
    }
}