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
        string[] tabUsd = new string[30];
        string[] tabEur = new string[30];
        string[] tabGbp = new string[30];
        string[] tabChF = new string[30];
        
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
            Course.GetCourseStatistic(ref tabUsd, "usd");
            Course.GetCourseStatistic(ref tabEur, "eur");
            Course.GetCourseStatistic(ref tabGbp, "gbp");
            Course.GetCourseStatistic(ref tabChF, "chf");
            for (int i = 0; i < tabDate.Length; i++)
            {
                CurrenclyList.Add(new Currency(tabDate[i], tabUsd[i], tabEur[i], tabGbp[i], tabChF[i]));
            }

            listView.ItemsSource = CurrenclyList;
        }
    }
}
