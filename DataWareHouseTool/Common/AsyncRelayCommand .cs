using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataWareHouseTool.Common
{
    public class AsyncRelayCommand : ICommand
    {
        /// <summary>
        /// CanExecuteChanged EventHandler
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private readonly Func<object, Task> _action;
        private Task _task;
        private readonly Func<Task> _actionWithOutParameter;
        private bool _canExecute = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public AsyncRelayCommand(Func<object, Task> action)
        {
            _action = action;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="actionWithOutParameter"></param>
        public AsyncRelayCommand(Func<Task> actionWithOutParameter)
        {
            _actionWithOutParameter = actionWithOutParameter;
        }

        /// <summary>
        /// On Can Execute Changed
        /// </summary>
        private void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Check if the task can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => _canExecute && (_task == null || _task.IsCompleted);

        /// <summary>
        /// Execute the task
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        {
            if (_action != null)
            {
                _task = _action(parameter);
                OnCanExecuteChanged();
                if (_task != null)
                {
                    await _task;
                }
                OnCanExecuteChanged();
            }
            else
            {
                _task = _actionWithOutParameter?.Invoke();
                OnCanExecuteChanged();
                await _task;
                OnCanExecuteChanged();
            }
        }
        
        public void ChangeCanExecute() => _canExecute = !_canExecute;
    }
}