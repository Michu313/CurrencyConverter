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
        float[] Currency1 = new float[30];
        float[] Currency2 = new float[30];
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
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public void InitializeList()
        {
            listView.Items.Clear();
            List<string> test = new List<string>();
            Course.GetCourseDate(ref tabDate);
            Course.GetCourseStatistic(ref Currency1, comboBoxCurrency1.Text.ToString());
            Course.GetCourseStatistic(ref Currency2, comboBoxCurrency2.Text.ToString());
            Helper.SelectImage(Currency1, ref Image1);
            Helper.SelectImage(Currency2, ref Image2);
            

            for (int i = 0; i < tabDate.Length; i++)
            {
                listView.Items.Add(new Currency(Image1[i], 0, Currency1[i], tabDate[i], Currency2[i], 0, Image2[i]));
            }
        }

        private void RefreshList(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            Course.GetCourseDate(ref tabDate);
            Course.GetCourseStatistic(ref Currency1, comboBoxCurrency1.Text.ToString());
            Course.GetCourseStatistic(ref Currency2, comboBoxCurrency2.Text.ToString());
            Helper.SelectImage(Currency1, ref Image1);
            Helper.SelectImage(Currency2, ref Image2);
            
            for (int i = 0; i < tabDate.Length; i++)
            {
                listView.Items.Add(new Currency(Image1[i], 0, Currency1[i], tabDate[i], Currency2[i], 0, Image2[i]));
            }
        }
    }
}
