using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Data.Logger;
using SeptemberUIChallenge.Services;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public abstract class BasePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructor

        public BasePageModel()
        {
            Logger = DependencyService.Get<ILogger>();
            AlertService = DependencyService.Get<IAlertService>();
            ConnectionManager = DependencyService.Get<IConnectionManager>();
        }
        
        #endregion Constructor

        #region Properties

        public bool IsBusy { get; set; }
        protected ILogger Logger { get; }
        protected IAlertService AlertService { get; }
        protected IConnectionManager ConnectionManager { get; }

        #endregion Properties

    }
}