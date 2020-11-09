﻿using System.Windows;
using System.Windows.Controls;
using MvvmNext.Command;

namespace MVVMNext.Controls
{
    /// <summary>
    /// Interaction logic for StateButtons.xaml
    /// </summary>
    public partial class StateButtons : Border
    {
        private Window _parentWindow;
        public StateButtons()
        {
            InitializeComponent();
            MinimizeButton.Command = new RelayCommand<object>((o) => Click_Minimize()) ;
        }

        private void Click_Minimize()
        {
            if (_parentWindow != null)
            {
                _parentWindow.WindowState = WindowState.Minimized;
            }
        }
            

        private void Click_Maximize(object sender, RoutedEventArgs e)
        {
            if (_parentWindow != null)
            {
                switch (_parentWindow.WindowState)
                {
                    case WindowState.Normal:
                        _parentWindow.WindowState = WindowState.Maximized;
                        break;
                    case WindowState.Minimized:
                        break;
                    case WindowState.Maximized:
                        _parentWindow.WindowState = WindowState.Normal;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            _parentWindow?.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = Window.GetWindow(this);
        }
    }
}