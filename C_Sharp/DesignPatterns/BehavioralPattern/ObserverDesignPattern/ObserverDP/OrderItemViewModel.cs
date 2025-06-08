using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ObserverDP
{
    internal class OrderItemViewModel : INotifyPropertyChanged
    {
        private int _quantity;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Description { get; }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
            }
        }


        public ICommand IncreaseQuantityCommand { get; }

        public OrderItemViewModel(string description)
        {
            Description = description;
            //_quantity = 1;
            IncreaseQuantityCommand = new IncreaseOrderItemQuantityCommand(this);
        }
    }
}
