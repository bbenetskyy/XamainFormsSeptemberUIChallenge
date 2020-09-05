using System.ComponentModel;

namespace SeptemberUIChallenge.PageModels
{
    public class BasePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}