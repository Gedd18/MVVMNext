using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMNext.Controls
{
    /// <summary>
    /// Interaction logic for DropBorder.xaml
    /// </summary>
    public partial class DropBorder : Border
    {
        private Window _parentWindow;

        public DropBorder()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_parentWindow != null) _parentWindow.DragMove();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = Window.GetWindow(this);
        }
    }
}
