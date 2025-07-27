using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TaskWPF4_1_DependecyProperty
{
    public class CustomButton : Button
    {
        public static readonly DependencyProperty IsToogledProperty = DependencyProperty.Register(
                nameof(IsToggled),
                typeof(bool),
                typeof(CustomButton),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    OnIsToogledChanged,
                    null)
                );

        public CustomButton()
        {
            Content = "OFF";
            Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            Click += (sender, e) => IsToggled = !IsToggled;
        }

        private static void OnIsToogledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (CustomButton)d;
            bool newValue = (bool)e.NewValue;

            button.Content = newValue == true ? "ON" : "OFF";
            button.Background = newValue == true ? new SolidColorBrush(Color.FromRgb(0, 255, 0)) : new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        public bool IsToggled
        {
            get { return (bool)GetValue(IsToogledProperty); }
            set { SetValue(IsToogledProperty, value); }
        }
    }
}
