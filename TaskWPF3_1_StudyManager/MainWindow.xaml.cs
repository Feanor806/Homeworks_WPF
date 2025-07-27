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

        private void EduHours_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hours.Text = EduHours.Value.ToString();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            //Проверка заполнения ФИО студента
            if (studentName.Text == null || studentName.Text == "")
            {
                MessageBox.Show("Не указано ФИО студента.", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string name = studentName.Text;

            //Проверка выбора факультета
            if (faculty.SelectedItem == null) 
            {
                MessageBox.Show("Не выбран факультет.", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string? facultyName = faculty.Text;

            //Проверка выбора курсов
            if (courses.SelectedItems.Count < 1)
            {
                MessageBox.Show("Не выбраны желаемые курсы.", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string coursesToLearn = "";
            foreach (string courseName in courses.SelectedItems.Cast<string>().ToList())
            {
                if (coursesToLearn == "") coursesToLearn += courseName;
                else coursesToLearn += ", " + courseName;
            }
            List<string> coursesList = courses.SelectedItems.Cast<string>().ToList();

            //Проверка наличия согласия
            if (!(bool)approval.IsChecked)
            {
                MessageBox.Show("Необходимо дать согласие на обработку данных", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string educationForm = (bool)fullTime.IsChecked ? "Очная" : "Заочная";
            int hours = (int)EduHours.Value;

            MessageBox.Show($"Студент: {name}\nФакультет: {facultyName}\nКурсы: {coursesToLearn}\nФорма обучения: {educationForm}\nЧисло часов в неделю: {hours}", "Данные отправлены",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(1);

        }

        private void faculty_MouseLeave(object sender, MouseEventArgs e)
        {
            if (faculty.SelectedItem == null) return;
            courses.Items.Clear();

            switch (faculty.Text)
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