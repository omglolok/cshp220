using PostalCodes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PostalCode
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
        string usPostalRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        string caPostalRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        private bool IsValidPostalCode(string PostalCode)
        {
            var isValidPostalCode = true;
            if ((!Regex.Match(PostalCode, usPostalRegEx).Success) && (!Regex.Match(PostalCode, caPostalRegEx).Success))
            {
                isValidPostalCode = false;
            }
            return isValidPostalCode;
        }

        private void txt_PostalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidPostalCode(txt_PostalCode.Text))
            {
                btn_Submit.IsEnabled = true;
            }
            else btn_Submit.IsEnabled = false;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{txt_PostalCode.Text} is a valid zip code.");
            PostalCodes.IPostalCodeFactory
        }
    }
}

