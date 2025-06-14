using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDP
{
    internal class OrderItemView : IDisposable
    {
        private readonly OrderItemViewModel _viewModel;

        public OrderItemView(OrderItemViewModel viewModel)
        {
            _viewModel = viewModel;

            SubscribeToViewModelPropertyChange();

            Print();
        }

        private void SubscribeToViewModelPropertyChange()
        {
            UnSubscribeToViewModelPropertyChange();

            /* Here, we are subscribing our View to the property changes event of View Model,
            *  It causes our View Model to have a reference to our View
            *  Since, our View Model is having reference to our View, 
            *  Garbage Collector will not be able to collect the View if it is not used anymore.
            *  Hence, we have to un-subscribe from the event when we are done with the View so that Garbage Collector can collect the View to avoid memory leaks.
            */
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void UnSubscribeToViewModelPropertyChange()
        {
            /* Here, we are subscribing our View to the property changes event of View Model,
            *  It causes our View Model to have a reference to our View
            *  Since, our View Model is having reference to our View, 
            *  Garbage Collector will not be able to collect the View if it is not used anymore.
            *  Hence, we have to un-subscribe from the event when we are done with the View so that Garbage Collector can collect the View to avoid memory leaks.
            */
            _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
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

        public void Dispose()
        {
            UnSubscribeToViewModelPropertyChange();
        }
    }
}
