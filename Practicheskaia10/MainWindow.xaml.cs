using System;
using System.Security.Cryptography.X509Certificates;
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

namespace Practicheskaia10
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

        List<int> mas = new List<int>();
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            while(mas.Count < 5)
            {
                mas.Add(rnd.Next(-30,100));
            }
            for (int i = 0; i < mas.Count; i++)
            {
                listBoxMas.Items.Add(mas[i].ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = sender as Button;
            switch (s.Content)
            {
                case "Поменять максимальное и минимально значение местами":MasCalc(); break;
                case "Информация": MessageBox.Show("Туда сюда"); break;
                case "Выход":Close(); break;
            }
        }
        private void MasCalc()
        {
            int minNumber = 0;
            int maxNumber = 0;
            int maxIndex = 0;
            int minIndex = 0;
            for (int i = 0; i < mas.Count; i++)
            {
                if (mas[i] > maxNumber)
                {
                    maxNumber = mas[i];
                    maxIndex = i;
                }
            }
            for (int j = 0; j < mas.Count; j++)
            {
                if (mas[j] < minNumber)
                {
                    minNumber = mas[j];
                    minIndex = j;
                }
            }
            maxNumber = mas[maxIndex];
            minNumber = mas[minIndex];
            Swap<int>(ref maxNumber, ref minNumber);
            mas[maxIndex] = maxNumber;
            mas[minIndex] = minNumber;
            listBoxMas.Items.Clear();
            for (int i = 0; i < mas.Count; i++) listBoxMas.Items.Add(mas[i].ToString());
        }
        public static void Swap<T>(ref T masReplaceItem, ref T masItem1)
        {
            T temp = masReplaceItem;
            masReplaceItem = masItem1;
            masItem1 = temp;
        }

    }
}