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

namespace ItemPanelTemplate;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Product> Products { get; set; }
    public MainWindow()
    {
        InitializeComponent();

        Products = new ObservableCollection<Product>()
        {
            new Product()
            {
                Name = "Product A",
                Description = "Product A Description"
            },

            new Product()
            {
                Name = "Product B",
                Description = "Product B Description"
            }
        };

        this.DataContext = this;
    }
}