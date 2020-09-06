using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MLToolkit.Forms.SwipeCardView.Core;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public class CardsPageModel
    {
        private readonly IUserService _userService;

        #region Fields

        #endregion Fields

        #region Constructor

        public CardsPageModel(
            IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<UserDetails>();
            PageAppearingCommand = new AsyncCommand(ExecutePageAppearingCommand);
            CardDraggingCommand = new Command<DraggingCardEventArgs>(ExecuteCardDraggingCommand);
        }

        #endregion Constructor

        #region Properties

        public bool IsBusy { get; set; }
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
                else if (args.Direction == SwipeCardDirection.Left)
                {
                    //todo remove from collection
                }
            }
            catch (Exception e)
            {
                //in real app it should be replaced with logger
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
        }

        private async Task ExecutePageAppearingCommand()
        {
            try
            {
                IsBusy = true;
                Users.Clear();
                var users = await _userService.GetUserList();
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