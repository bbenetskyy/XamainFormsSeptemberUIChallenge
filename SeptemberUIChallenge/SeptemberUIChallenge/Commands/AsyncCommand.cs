using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeptemberUIChallenge.Commands
{
    public class AsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        #region Fields
        
        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        
        #endregion Fields
        
        #region Constructor
        
        public AsyncCommand(
            Func<Task> execute,
            Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        #endregion Constructor

        #region Public Methods

        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        
        #endregion Public Methods

        #region Explicit implementations
       
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
#pragma warning disable 4014
            ExecuteAsync();
#pragma warning restore 4014
        }
        
        #endregion Explicit implementations
    }
}