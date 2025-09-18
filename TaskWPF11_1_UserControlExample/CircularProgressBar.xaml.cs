using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskWPF11_1_UserControlExample
{
    /// <summary>
    /// Логика взаимодействия для CircularProgressBar.xaml
    /// </summary> 
    public partial class CircularProgressBar : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnValueChanged));

        //Конечная точка дуги прогресса
        public static readonly DependencyProperty ProgressEndPointProperty =
            DependencyProperty.Register(
                nameof(ProgressEndPoint),
                typeof(Point), 
                typeof(CircularProgressBar),
                new PropertyMetadata(new Point(50, 95)));

        //Флаг определения дуги - до середины круга малая дуга, после - большая.
        public static readonly DependencyProperty IsLargeArcProperty =
             DependencyProperty.Register(
                 nameof(IsLargeArc), 
                 typeof(bool), 
                 typeof(CircularProgressBar),
                 new PropertyMetadata(false));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(100.0, OnValueChanged));

        // Read-only Dependency Properties
        private static readonly DependencyPropertyKey ProgressAnglePropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(ProgressAngle),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty ProgressAngleProperty = ProgressAnglePropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey PercentageTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(PercentageText),
                typeof(string),
                typeof(CircularProgressBar),
                new PropertyMetadata("0%"));

        public static readonly DependencyProperty PercentageTextProperty = PercentageTextPropertyKey.DependencyProperty;

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public Point ProgressEndPoint
        {
            get => (Point)GetValue(ProgressEndPointProperty);
            set => SetValue(ProgressEndPointProperty, value);
        }
        public bool IsLargeArc
        {
            get => (bool)GetValue(IsLargeArcProperty);
            set => SetValue(IsLargeArcProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public double ProgressAngle
        {
            get => (double)GetValue(ProgressAngleProperty);
            private set => SetValue(ProgressAnglePropertyKey, value);
        }

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            private set => SetValue(PercentageTextPropertyKey, value);
        }

        public CircularProgressBar()
        {
            InitializeComponent();
            UpdateProgressGeometry();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = (CircularProgressBar)d;
            progressBar.UpdateProgressGeometry();
        }

        private void UpdateProgressGeometry()
        {
            // Вычисляем прогресс
            double percentage = Maximum == 0 ? 0 : (Value / Maximum);
            double angle = 360 * percentage==360?359:360 * percentage;
            ProgressAngle = angle;
            PercentageText = $"{(percentage * 100):F0}%";

            // Параметры круга
            double centerX = 50;
            double centerY = 50;
            double radius = 45;

            // Начинаем с нижней точки (90°)
            double startAngle = 90;

            // Конечный угол = начальный + прогресс по часовой стрелке
            double endAngle = startAngle + angle;

            // Нормализуем угол
            endAngle %= 360;
            if (endAngle < 0) endAngle += 360;

            // Конвертируем в радианы
            double endRadians = endAngle * Math.PI / 180;

            // Вычисляем координаты (в WPF: cos для X, sin для Y)
            double x = centerX + radius * Math.Cos(endRadians);
            double y = centerY + radius * Math.Sin(endRadians);

            ProgressEndPoint = new Point(x, y);

            // Правильное определение большой/малой дуги
            IsLargeArc = angle > 180;
        }
    }
}
