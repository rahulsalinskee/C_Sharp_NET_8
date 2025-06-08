using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ObserverDP
{
    internal class IncreaseOrderItemQuantityCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private OrderItemViewModel _viewModel;

        public IncreaseOrderItemQuantityCommand(OrderItemViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Quantity++;
        }
    }
}
