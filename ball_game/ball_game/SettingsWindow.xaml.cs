using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ball_game
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public static int themeID = 0;        
        public SettingsWindow()
        {
            InitializeComponent();
            if (SettingsWindow.themeID == 1)
            {
                SettingsWindow.painting(255, 172, 150, 183, 181, 46, 31, 128, 245, 189, 104, 203, grid);
            }
            if (SettingsWindow.themeID == 2)
            {
                SettingsWindow.painting(255, 68, 167, 159, 164, 74, 153, 97, 196, 116, 167, 180, grid);
            }
        }

        public void label9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        public static void painting(byte o1, byte r1, byte g1, byte b1, byte o2, byte r2, byte g2, byte b2, byte o3, byte r3, byte g3, byte b3, Grid grid)
        {
            Color color1 = Color.FromArgb(o1, r1, g1, b1);
            Color color2 = Color.FromArgb(o2, r2, g2, b2);
            Color color3 = Color.FromArgb(o3, r3, g3, b3);

            LinearGradientBrush gradient = new LinearGradientBrush();
            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 1);
            gradient.GradientStops.Add(
                new GradientStop(color1, 0.0));
            gradient.GradientStops.Add(
                new GradientStop(color2, 0.5));
            gradient.GradientStops.Add(
                new GradientStop(color3, 1.0));

            grid.Background = gradient;             
        
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            themeID = 2;
            image2.Opacity = 1;
            image1.Opacity = 0.7;
        }

        private void image1_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            themeID = 1;
            image1.Opacity = 1;
            image2.Opacity = 0.7;
        }


    }
}
