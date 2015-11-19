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
    /// Логика взаимодействия для GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public static int result_import;
        public GameOverWindow()
        {
            InitializeComponent();
            label7.Content += result_import.ToString();
            if (SettingsWindow.themeID == 1)
            {
                SettingsWindow.painting(255, 172, 150, 183, 181, 46, 31, 128, 245, 189, 104, 203, grid);
            }
            if (SettingsWindow.themeID == 2)
            {
                SettingsWindow.painting(255, 68, 167, 159, 164, 74, 153, 97, 196, 116, 167, 180, grid);
            }
        }

        private void label9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
              
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
