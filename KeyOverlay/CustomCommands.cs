using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace KeyOverlay
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(CustomCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.F4, ModifierKeys.Alt)
        });

        public static readonly RoutedUICommand PressShift = new RoutedUICommand("Shift", "Shift", typeof(CustomCommands));
        public static readonly RoutedUICommand DockRight = new RoutedUICommand("Dock Right", "Dock Right", typeof(CustomCommands));
    }
}