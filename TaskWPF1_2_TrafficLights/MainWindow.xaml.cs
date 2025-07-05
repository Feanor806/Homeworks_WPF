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

namespace TaskWPF1_2_TrafficLights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int step = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (step)
            {
                case 1:
                    step = 2;
                    Red.Fill = new SolidColorBrush(Color.FromRgb(210, 60, 30));
                    Yellow.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                    break;
                case 2:
                    step = 3;
                    Yellow.Fill = new SolidColorBrush(Color.FromRgb(230, 240, 10));
                    break;
                case 3:
                    step = 4;
                    Red.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                    Yellow.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                    Green.Fill = new SolidColorBrush(Color.FromRgb(40, 240, 10));
                    break;
                case 4:
                    step = 1;
                    Yellow.Fill = new SolidColorBrush(Color.FromRgb(230, 240, 10));
                    Green.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                    break;
            }
        }
    }
}