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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ball_game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GameWindow gw = new GameWindow();
            gw.Show();
            this.Close();
        }

        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScoresWindow sw = new ScoresWindow();
            sw.Show();
            this.Hide();

            GameWindow.path = System.IO.Path.GetFullPath(@"D:\Programs\Visual Studio\.net\ball_game\ball_game\ball_game\scores"); //шлях до текстового файлу, у якому будуть зберігатись результати
            DirectoryInfo dir = new DirectoryInfo(GameWindow.path);

            foreach (FileInfo file in dir.GetFiles()) // перебір файлів(1) у спеціальній директорії
            {
                string[] lines = File.ReadAllLines(@file.FullName, Encoding.Default); // зчитування файлу із результатами у масив стрічок
                string[] names = new string[5]; // масив стрічок для імен користувачів
                int[] sorted_array = new int[(lines.Length)]; // масив чисел для кращих результатів

                // цикл, у якому здійснюється передача результатів із файлу у  масив чисел
                for (int i = 1; i < lines.Length; i += 2)
                {
                    sorted_array[i] = int.Parse(lines[i]);
                }

                Array.Sort(sorted_array); // сортування результатів (від найменшого)

                /* порівняння значень із масиву чисел та з файлу з метою одинакового індексування масиву імен та результатів *БУДЕ ОНОВЛЕНО ПІЗНІШЕ*
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 1; j < lines.Length -1 ; j += 2)
                    {
                        if (sorted_array[i] == int.Parse(lines[j]))
                            names[i] = lines[j - 1];
                    }
                }*/

                // виведення кращих результатів, та імен їх власників
                label4.Content += sorted_array[sorted_array.Length - 4].ToString() + names[4];
                label3.Content += sorted_array[sorted_array.Length - 3].ToString() + names[3];
                label2.Content += sorted_array[sorted_array.Length - 2].ToString() + names[2];
                label1.Content += sorted_array[sorted_array.Length - 1].ToString() + names[1];
            }
        }
    }
}
