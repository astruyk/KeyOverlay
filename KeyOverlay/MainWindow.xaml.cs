using System;
using System.Collections.Generic;
using System.Linq;
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

namespace KeyOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDocked = false;
        private bool _isShiftPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandDock_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandDock_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_isDocked)
            {
                WpfAppBar.AppBarFunctions.SetAppBar(this, WpfAppBar.ABEdge.None);
            }
            else
            {
                WpfAppBar.AppBarFunctions.SetAppBar(this, WpfAppBar.ABEdge.Right, grid);
            }
            _isDocked = !_isDocked;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            _isDocked = true;
           WpfAppBar.AppBarFunctions.SetAppBar(this, WpfAppBar.ABEdge.Right, grid);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isDocked)
            {
                WpfAppBar.AppBarFunctions.SetAppBar(this, WpfAppBar.ABEdge.None);
            }
        }

        private void CommandShift_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandShift_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var simulator = new WindowsInput.InputSimulator();
            if (_isShiftPressed)
            {
                simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.SHIFT);
            }
            else
            {
                simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.SHIFT);
            }
            _isShiftPressed = !_isShiftPressed;
        }

        
    }
}
