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

namespace TaskWPF8_1_DataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products {get;} = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Products.Add(new Product()
            {
                ProductName = "Банан",
                ProductPrice = new decimal(120.00),
                ImagePath = @"\banana.jpg",
                ProductType = ProductTypes.Food
            });

            Products.Add(new Product()
            {
                ProductName = "Стиральная машина",
                ProductPrice = new decimal(40000.00),
                ImagePath = @"\WashinfMachine.jpg",
                ProductType = ProductTypes.HomeAppliances
            });

            Products.Add(new Product()
            {
                ProductName = "Киви",
                ProductPrice = new decimal(240.00),
                ImagePath = @"\kiwi.jpg",
                ProductType = ProductTypes.Food
            });
        }
    }
}