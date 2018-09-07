using CurrencyConverter.OfflineCourseCurrent;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CompleteAll();
        }


        public void CompleteAll()
        {
            if (Helper.CheckConnectInternet()==true)
            {
                CompleteCheckBoxOnline();
                connection.Content = "Online";
                control.Fill= Brushes.Green;
                CreateXml createXml = new CreateXml();
                BRefresh.IsEnabled = false;
                BStatistic.IsEnabled = true;
                OfflineDataCurrency.Content = "";
            }
            else
            {
                CompleteCheckBoxOffline();
                connection.Content = "Offline";
                control.Fill = Brushes.Red;
                BRefresh.IsEnabled = true;
                BStatistic.IsEnabled = false;
                OfflineDataCurrency.Content = "Kursy walut z dnia: " + Helper.ReversDate();
            }

            Helper.AddItemToComboBoxList(ref comboBox1, true, Helper.CheckConnectInternet());
            Helper.AddItemToComboBoxList(ref comboBox2, true, Helper.CheckConnectInternet());
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            textBox1.Focus();
            textBox2.IsReadOnly = true;
        }

        public void CompleteCheckBoxOnline()
        {
            labeCourseUsd.Content = labeCourseUsd.Content + "" + Helper.RoundFloat(Helper.StringToFloat(Course.GetCourse("USD")), 2);
            labeCourseEur.Content = labeCourseEur.Content + "" + Helper.RoundFloat(Helper.StringToFloat(Course.GetCourse("EUR")), 2);
            labeCourseGbp.Content = labeCourseGbp.Content + "" + Helper.RoundFloat(Helper.StringToFloat(Course.GetCourse("GBP")), 2);
            labeCourseChf.Content = labeCourseChf.Content + "" + Helper.RoundFloat(Helper.StringToFloat(Course.GetCourse("CHF")), 2);
        }

        public void CompleteCheckBoxOffline()
        {
            labeCourseUsd.Content = labeCourseUsd.Content + "" + Convert.ToString(Math.Round(CourseOffline.GetValueCurrenc("USD"), 2));
            labeCourseEur.Content = labeCourseEur.Content + "" + Convert.ToString(Math.Round(CourseOffline.GetValueCurrenc("EUR"), 2));
            labeCourseGbp.Content = labeCourseGbp.Content + "" + Convert.ToString(Math.Round(CourseOffline.GetValueCurrenc("GBP"), 2));
            labeCourseChf.Content = labeCourseChf.Content + "" + Convert.ToString(Math.Round(CourseOffline.GetValueCurrenc("CHF"), 2));
        }

        private void Button_ClickConvert(object sender, RoutedEventArgs e)
        {
            if (Helper.CheckTextBox(textBox1.Text)==true)
            {
                if (Helper.CheckConnectInternet() == true)
                    ConverterOnline();
                else
                    ConverterOffline();
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Nie poprawny format ciągu wejściowego. Przykładowe formaty: 100 | 12.23 | 1245.54", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        public void ConverterOnline()
        {
            string cb1 = comboBox1.Text.ToString();
            string cb2 = comboBox2.Text.ToString();
            float b = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
            textBox2.Text = "";
            if (cb1 == "PLN")
            {
                string a = "" + Helper.RoundFloat(Course.ConvertPlnToOthe(Helper.StringToFloat(Course.GetCourse(cb2)), b), 2);
                textBox2.AppendText(a);
            }
            else if (cb2 == "PLN")
            {
                string a = "" + Helper.RoundFloat(Course.ConvertOthersToPln(Helper.StringToFloat(Course.GetCourse(cb1)), b), 2);
                textBox2.AppendText(a);
            }
            else
            {
                string a = "" + Helper.RoundFloat(Course.ConvertOtherstoOthers(Helper.StringToFloat(Course.GetCourse(cb1)), Helper.StringToFloat(Course.GetCourse(cb2)), b), 2);
                textBox2.AppendText(a);
            }
        }

        public void ConverterOffline()
        {
            string cb1 = comboBox1.Text.ToString();
            string cb2 = comboBox2.Text.ToString();
            float b = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
            textBox2.Text = "";
            if (cb1 == "PLN")
            {
                string a = "" + Helper.RoundFloat(Course.ConvertPlnToOthe(CourseOffline.GetValueCurrenc(cb2), b), 2);
                textBox2.AppendText(a);
            }
            else if (cb2 == "PLN")
            {
                string a = "" + Helper.RoundFloat(Course.ConvertOthersToPln(CourseOffline.GetValueCurrenc(cb1), b), 2);
                textBox2.AppendText(a);
            }
            else
            {
                string a = "" + Helper.RoundFloat(Course.ConvertOtherstoOthers(CourseOffline.GetValueCurrenc(cb1), CourseOffline.GetValueCurrenc(cb2), b), 2);
                textBox2.AppendText(a);
            }
        }

        private void Button_Statistic(object sender, RoutedEventArgs e)
        {
            StatisticCurrency statistic = new StatisticCurrency();
            statistic.Show();
            this.Close();
        }

        private void RefreshConnect(object sender, RoutedEventArgs e)
        {
            CompleteAll();
        }
    }
}
