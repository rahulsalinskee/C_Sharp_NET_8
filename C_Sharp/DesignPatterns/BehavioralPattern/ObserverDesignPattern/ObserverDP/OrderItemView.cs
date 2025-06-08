using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDP
{
    internal class OrderItemView
    {
        private readonly OrderItemViewModel _viewModel;

        public OrderItemView(OrderItemViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            Print();
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Print();
        }

        public void ClickIncreaseQuantityButton()
        {
            _viewModel.IncreaseQuantityCommand.Execute(null);
            Print();
        }

        private void Print()
        {
            Console.WriteLine($"{_viewModel.Description} X {_viewModel.Quantity}");
        }
    }
}
