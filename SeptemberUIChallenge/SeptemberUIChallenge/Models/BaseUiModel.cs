using System.ComponentModel;

namespace SeptemberUIChallenge.Models
{
    public class BaseUiModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}