using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemTemplate
{
    public class Product : INotifyPropertyChanged
    {
        public string ImagePath { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
