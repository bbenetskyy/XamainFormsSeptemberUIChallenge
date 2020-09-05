using System.Threading.Tasks;
using System.Windows.Input;

namespace SeptemberUIChallenge.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
        void RaiseCanExecuteChanged();
    }
}