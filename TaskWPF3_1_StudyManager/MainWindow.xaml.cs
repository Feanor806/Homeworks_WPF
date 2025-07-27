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

namespace TaskWPF3_1_StudyManager
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

        private void refreshCourses_Click(object sender, RoutedEventArgs e)
        {
            if (faculty.SelectedItem == null) return;
            courses.Items.Clear();

            switch (faculty.SelectedItem.ToString())
            {
                case "Программирование":
                    courses.Items.Add("Программирование C#");
                    courses.Items.Add("Программирование Python");
                    courses.Items.Add("Программирование 1C");
                    break;
                case "Строительство":
                    courses.Items.Add("Архитектурные решения");
                    courses.Items.Add("Проектирование конструктивных элементов");
                    courses.Items.Add("Генплан и ландшафтный дизайн");
                    break;
                case "Теплогазоснабжение и вентиляция":
                    courses.Items.Add("Проектирование систем отопления");
                    courses.Items.Add("Противодымная вентиляция зданий и сооружений");
                    courses.Items.Add("Кондиционирование и микроклимат");
                    break;
                default:
                    break;
            }
        }
    }
}