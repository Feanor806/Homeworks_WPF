using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskWPF9_1_Comands
{
    internal class CustomCommands
    {
        public static RoutedCommand ChangeColor {  get; set; }
        static CustomCommands()
        {
            InputGestureCollection inputGestureCollection = new InputGestureCollection();
            inputGestureCollection.Add(new KeyGesture(Key.C, ModifierKeys.Control, "Ctrl+C"));
            ChangeColor = new RoutedUICommand("ChangeColor", "ChangeColor", typeof(CustomCommands), inputGestureCollection);
        }
    }
}
