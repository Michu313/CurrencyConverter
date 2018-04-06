using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for StatisticCurrency.xaml
    /// </summary>
    public partial class StatisticCurrency : Window
    {
        List<Currency> CurrenclyList = new List<Currency>();
        string[] tabDate = new string[30];
        float[,] Currency = new float[30,4];
        string[,] Image = new string[30, 4];
         
        
        public StatisticCurrency()
        {
            InitializeComponent();
            InitializeList();
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public void InitializeList()
        {
            List<string> test = new List<string>();
            Course.GetCourseDate(ref tabDate);
            Course.GetCourseStatistic(ref Currency, "usd");
            Course.GetCourseStatistic(ref Currency, "eur");
            Course.GetCourseStatistic(ref Currency, "gbp");
            Course.GetCourseStatistic(ref Currency, "chf");
            Helpes.SelectImage( Currency, ref Image, 0);
            Helpes.SelectImage( Currency, ref Image, 1);
            Helpes.SelectImage( Currency, ref Image, 2);
            Helpes.SelectImage( Currency, ref Image, 3);



            for (int i = 0; i < tabDate.Length; i++)
            {
                CurrenclyList.Add(new Currency(tabDate[i], Currency[i,0], Image[i,0], Currency[i, 1], Image[i, 1], Currency[i, 2], Image[i, 2], Currency[i, 3], Image[i, 3]));
            }

            listView.ItemsSource = CurrenclyList;
        }
    }
}
