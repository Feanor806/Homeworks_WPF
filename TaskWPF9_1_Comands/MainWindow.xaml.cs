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

namespace TaskWPF9_1_Comands
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

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop(); // Удаляем текущий цвет
                CurrentColor = _colorHistory.Pop(); // Берём предыдущий
            }
        }
        private void UndoCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private Stack<Brush> _colorHistory = new Stack<Brush>();

        private Brush _currentColor;

        // Текущий цвет
        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _currentColor = value;

                // Добавляем новый цвет в стек, если предыдущий цвет не такой же
                // (либо стек пустой) 
                if (_colorHistory.Count == 0 || _colorHistory.Peek() != value)
                {
                    _colorHistory.Push(value);
                }
                // Dock - это имя (x:Name) контейнера компоновки, для которого меняем цвет
                Dock.Background = _currentColor;
            }
        }
        private void ChangeColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();
            // CurrentColor - это свойство для хранения текущего цвета
            // ниже описано, как оно устроено
            CurrentColor = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        }


    }
}