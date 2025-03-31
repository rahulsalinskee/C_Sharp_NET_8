using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemTemplate;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Product> ProductList { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        ProductList = new ObservableCollection<Product>()
        {
            new Product()
            {
                ImagePath = "images/product1.png",
                ProductName = "Product A",
                Price = 19.99m,
                Description = "This is a product A description"
            },

            new Product()
            {
                ImagePath = "images/product2.png",
                ProductName = "Product B",
                Price = 29.99m,
                Description = "This is a product B description"
            }
        };

        this.DataContext = this;
    }
}