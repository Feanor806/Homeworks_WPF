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

namespace TaskWPF1_3_RunningButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunningButton_MouseEnter(object sender, MouseEventArgs e)
        {
            int maxHeightMargin = (int)Borders.Height - 105;
            int maxWidthMargin = (int)Borders.Width - 180;

            Random rnd = new Random();

            int newHeightMargin = rnd.Next(0, maxHeightMargin);
            int newWidthMargin = rnd.Next(0, maxWidthMargin);

            RunningButton.Margin = new Thickness(newWidthMargin, newHeightMargin,0,0);
        }
    }
}