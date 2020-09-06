using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Commands;
using SeptemberUIChallenge.Data.Infrastructure;
using SeptemberUIChallenge.Data.Models;
using SeptemberUIChallenge.Services;
using Xamarin.Forms.Internals;

namespace SeptemberUIChallenge.PageModels
{
    public class FavouritesPageModel
    {
        private readonly IUserRepository _userRepository;

        #region Fields

        #endregion Fields

        #region Constructor

        public FavouritesPageModel(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            //todo we may eject it to some interface because we use it second time
            try
            {
                IsBusy = true;
                Users.Clear();
                var users = _userRepository.GetAllFavouritesUsers();
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