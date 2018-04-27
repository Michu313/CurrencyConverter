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
            labeCourseUsd.Content = labeCourseUsd.Content + "" + Helper.Round(Helper.StringToFloat(Course.GetCourse("USD")));
            labeCourseEur.Content = labeCourseEur.Content + "" + Helper.Round(Helper.StringToFloat(Course.GetCourse("EUR")));
            labeCourseGbp.Content = labeCourseGbp.Content + "" + Helper.Round(Helper.StringToFloat(Course.GetCourse("GBP")));
            labeCourseChf.Content = labeCourseChf.Content + "" + Helper.Round(Helper.StringToFloat(Course.GetCourse("CHF")));
            Helper.AddItemToComboBoxList(ref comboBox1, true);
            Helper.AddItemToComboBoxList(ref comboBox2, true);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            textBox1.Focus();
            textBox2.IsReadOnly = true; 
        }

        private void Button_ClickConvert(object sender, RoutedEventArgs e)
        {
            string cb1 = comboBox1.Text.ToString();
            string cb2 = comboBox2.Text.ToString();
            float b = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
            textBox2.Text = "";
            if (cb1 == "PLN")
            {
                string a = "" + Helper.Round(Course.ConvertPlnToOthe(Helper.StringToFloat(Course.GetCourse(cb2)), b));
                textBox2.AppendText(a);
            }
            else if (cb2 == "PLN")
            {
                string a = "" + Helper.Round(Course.ConvertOthersToPln(Helper.StringToFloat(Course.GetCourse(cb1)), b));
                textBox2.AppendText(a);
            }
            else
            {
                string a = "" + Helper.Round(Course.ConvertOtherstoOthers(Helper.StringToFloat(Course.GetCourse(cb1)), Helper.StringToFloat(Course.GetCourse(cb2)), b));
                textBox2.AppendText(a);
            }
        }

        private void Button_Statistic(object sender, RoutedEventArgs e)
        {
            StatisticCurrency statistic = new StatisticCurrency();
            statistic.Show();
            this.Close();
        }

        //private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
