using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Management.UI.Commands
{
    public class RelayCommand : ICommand 
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool> _canExecute;
        private bool _isExecuting;

        public RelayCommand()
        {
            
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
