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
using System.Timers;
using System.Windows.Media.Animation;
using System.IO;

namespace ball_game
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public static string path;
        public static string name;
        public static  int coeficient = 1;
        public static int lives = 4;
        public static int result = 0;
        double X = 0;
        double Y = 0;
        double x = 0;
        double y = 0;

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public GameWindow()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void timerTick(object sender, EventArgs e)
        {
            // рух м'ячика за траекторыэю X 
            if (x > 660)
            {
                X -= coeficient;
                if (X < 0) x = 0;
            };

            if (x == 0)
            {
                X += coeficient;
                if (X > 670) x = 670;
            };

            // рух м'ячика за траекторією Y
            if (y >310)
            {
                Y -= coeficient;
                if (Y < 0) y = 0;
            };

            if (y == 0)
            {
                Y += coeficient;
                if (Y > 320) y = 320;
            };

            ell.Margin = new Thickness(X,Y,0,0); // перемальовування м'ячика згідно зі зміненими координатами
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            label1.Visibility = System.Windows.Visibility.Hidden;
            label2.Visibility = System.Windows.Visibility.Visible;
            label3.Visibility = System.Windows.Visibility.Visible;
            ell.Visibility = System.Windows.Visibility.Visible;

            timer.Tick += new EventHandler(timerTick); // ініціалізація таймера
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // проміжок, через який буде спрацьовувати таймер
            timer.Start(); // початок роботи таймера

            ell.MouseLeftButtonDown += ell_MouseLeftButtonDown; // створення функції, яка буде виконуватись після кліку на об'єкт ell
        }

        
        private void ell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // пришвидшення руху м'ячика зі збільшенням очок
            result += 100 ;
            if (result > 1000)
                coeficient = 2;
            if (result > 2000)
                coeficient = 3;
            if (result > 3000)
                coeficient = 4;
            if (result > 4000)
                coeficient = 5;
            if (result > 5000)
                coeficient = 6;
            if (result > 6000)
                coeficient = 7;
            if (result > 7000)
                coeficient = 8;

            lives += 1;
            label4.Content = result.ToString();  
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lives -= 1;
            label6.Content = lives.ToString();
            GameOverWindow.result_import = result;

            // кінець гри, коли гравець витратив усі свої життя
            if (lives == 0)
            {
                label1.Visibility = System.Windows.Visibility.Hidden;
                label2.Visibility = System.Windows.Visibility.Hidden;
                label3.Visibility = System.Windows.Visibility.Hidden;
                label6.Visibility = System.Windows.Visibility.Hidden;
                label4.Visibility = System.Windows.Visibility.Hidden;
                ell.Visibility = System.Windows.Visibility.Hidden;            
                label9.Visibility = System.Windows.Visibility.Visible;
                result = 0;
                lives = 4;
                coeficient = 1;

                GameOverWindow gow = new GameOverWindow();
                gow.Show();
                this.Hide();
            }
        }

        /*private void label10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            path = System.IO.Path.GetFullPath(@"D:\Programs\Visual Studio\.net\ball_game\ball_game\ball_game\scores"); //шлях до текстового файлу, у якому будуть зберігатись результати
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo file in dir.GetFiles()) // перебір файлів(1) у спеціальній директорії
            {
                string[] lines = {name, result.ToString()}; // масив стрічок із двома стрічками, що характеризують ім'я гравця, та його результат
                File.AppendAllLines(@file.FullName, lines); // запис масиву стрічок у файл із результатами        
            }

            // перехід до головного вікна
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }*/

        private void Window_Closed(object sender, EventArgs e)
        {
            //Environment.Exit(0);
        }

        private void label5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void label9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

    }
}
