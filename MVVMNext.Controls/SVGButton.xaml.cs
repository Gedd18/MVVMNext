﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace MVVMNext.Controls
{
    /// <summary>
    /// Logique d'interaction pour SVGButton.xaml
    /// </summary>
    public partial class SVGButton : CommandPanel
    {
        /// <summary>
        /// SVG source file
        /// </summary>
        public string Source
        {
            get => img.Source;
            set
            {
                img.Source = value;
                Uri _uri = new Uri("pack://application:,,," + img.Source);
                StreamResourceInfo sri = Application.GetResourceStream(_uri);

                using (Stream s = sri.Stream)
                {
                    img.SetImage(s);
                }
            }
        }


        private Color? _baseColor;

        /// <summary>
        /// Drawing color when the mouse is over
        /// </summary>
        public Color? BaseColor
        {
            get => _baseColor;
            set { img.OverrideColor = value; _baseColor = value; Update(); }
        }

        public Color? OverColor
        {
            get;
            set;
        }

        public SVGButton()
        {
            InitializeComponent();
            MouseEnter += SVGButton_MouseEnter;
            MouseLeave += SVGButton_MouseLeave;
        }

        private void SVGButton_MouseLeave(object sender, MouseEventArgs e)
        {
            img.OverrideColor = _baseColor;
            Update();
        }

        private void SVGButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (OverColor != null) img.OverrideColor = OverColor;
            Update();
        }

        private void Update()
        {
            if (img.Source == null) return;
            Uri _uri = new Uri("pack://application:,,," + img.Source);
            StreamResourceInfo sri = Application.GetResourceStream(_uri);

            using (Stream s = sri.Stream)
            {
                img.SetImage(s);
            }
        }

        private void CommandPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}