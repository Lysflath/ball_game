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
using System.IO;

namespace ball_game
{
    /// <summary>
    /// Логика взаимодействия для ScoresWindow.xaml
    /// </summary>
    public partial class ScoresWindow : Window
    {
        public ScoresWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {                
        }
            

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }


    }
}
