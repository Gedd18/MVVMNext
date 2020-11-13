using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Resources;

namespace MVVMNext.Sample
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            svgimg.OverrideColor = (svgimg.OverrideColor==Colors.Red)?Colors.BlueViolet:Colors.Red;

            //svgimg.Source = "/MVVMNext.Controls;component/svg/restore-window.svg";

            StreamResourceInfo sri = Application.GetResourceStream(new Uri("pack://application:,,," + svgimg.Source));

            using (Stream s = sri.Stream)
            {
                svgimg.SetImage(s);
            }
            //svgimg.InvalidateVisual();
            //svgimg.ReRenderSvg();
        }
    }
}
