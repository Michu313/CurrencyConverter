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
        double[] Currency1 = new double[30];
        double[] Currency2 = new double[30];
        double[] ChangeTab1 = new double[30];
        double[] ChangeTab2 = new double[30];
        string[] Image1 = new string[30];
        string[] Image2 = new string[30];
        

        public StatisticCurrency()
        {
            InitializeComponent();            
            Helper.AddItemToComboBoxList(ref comboBoxCurrency1 ,false);
            Helper.AddItemToComboBoxList(ref comboBoxCurrency2, false);
            comboBoxCurrency1.SelectedIndex = 0;
            comboBoxCurrency2.SelectedIndex = 1;
            InitializeList();
            InitializeStatisticGroupBox();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public void InitializeStatisticGroupBox()
        {
            groupBoxStatistic1.Header = "Statystyka " + comboBoxCurrency1.Text.ToString()+":";
            groupBoxStatistic2.Header = "Statystyka " + comboBoxCurrency2.Text.ToString()+":";
        }

        public void InitializeList()
        {
            listView.Items.Clear();
            List<string> test = new List<string>();
            Course.GetCourseDate(ref tabDate);
            Course.GetCourseStatistic(ref Currency1, comboBoxCurrency1.Text.ToString(), tabDate);
            Course.GetCourseStatistic(ref Currency2, comboBoxCurrency2.Text.ToString(), tabDate);
            Helper.SelectImage(Currency1, ref Image1);
            Helper.SelectImage(Currency2, ref Image2);
            DetailedStatistic.ChangeCurrencyPrice(Currency1, ref ChangeTab1);
            DetailedStatistic.ChangeCurrencyPrice(Currency2, ref ChangeTab2);
            DetailedStatistic.FillTextBlock(ref textBlockCurrency11, ref textBlockCurrency12, ref textBlockCurrency13, ref textBlockCurrency14, ref textBlockCurrency15, Currency1, ChangeTab1);
            DetailedStatistic.FillTextBlock(ref textBlockCurrency21, ref textBlockCurrency22, ref textBlockCurrency23, ref textBlockCurrency24, ref textBlockCurrency25, Currency2, ChangeTab2);

            for (int i = 0; i < 30; i++)
            {
                listView.Items.Add(new Currency(Image1[i], Math.Round(ChangeTab1[i],4), Math.Round(Currency1[i],4), tabDate[i], Math.Round(Currency2[i],4), Math.Round(ChangeTab2[i], 4), Image2[i]));
            }
        }

        private void RefreshList(object sender, RoutedEventArgs e)
        {
            InitializeList();
            InitializeStatisticGroupBox();
        }
    }
}
