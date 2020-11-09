using MvvmNext.Command;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMNext.Controls
{
    public class CommandPanel : UserControl
    {
        
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(CommandPanel),
                new PropertyMetadata(null));

        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register(
                "Parameter",
                typeof(object),
                typeof(CommandPanel),
                new PropertyMetadata(null));


        public object Parameter
        {
            get { return (object)GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public CommandPanel()
        { 
            this.MouseDown += ActionControl_MouseDown;
        }

        private void ActionControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Command?.Execute(Parameter);
        }
    }
}
