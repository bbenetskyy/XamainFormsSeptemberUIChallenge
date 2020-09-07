using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SeptemberUIChallenge.Data.Logger;
using Xamarin.Forms;

namespace SeptemberUIChallenge.PageModels
{
    public abstract class BasePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructor

        public BasePageModel(ILogger logger)
        {
            Logger = logger;
        }
        
        #endregion Constructor

        #region Properties

        public bool IsBusy { get; set; }
        protected ILogger Logger { get; }

        #endregion Properties

    }
}