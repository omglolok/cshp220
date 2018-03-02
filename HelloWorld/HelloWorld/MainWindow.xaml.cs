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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorld
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else 
            WindowState = WindowState.Maximized;
        }

        private void EnableSignIn()
        {
            var usernameLength = username.Text.Length;
            var passwordLength = password.Text.Length;
            if (usernameLength >= 10 && passwordLength >= 10)
            {
                btnSignIn.IsEnabled = true;
            }
            else btnSignIn.IsEnabled = false;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (username.Text.Length >= 9) {
                EnableSignIn();
            }
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)

        {
            if (password.Text.Length >= 9)
            {
                EnableSignIn();
            }
        }
        private void username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (username.Text.Length < 10)
            {
                usernameAlert.Visibility = Visibility.Visible;
                usernameAlert.Text = "Username must be at least 10 characters long";
            } else
            {
                usernameAlert.Visibility = Visibility.Hidden;
            }

            if (username.Text.Length == 0)
            {
                labelUsername.Visibility = Visibility.Visible;
            }


        }

        private void username_GotFocus(object sender, RoutedEventArgs e)
        {
            labelUsername.Visibility = Visibility.Hidden;
        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            labelPassword.Visibility = Visibility.Hidden;
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password.Text.Length < 10)
            {
                passwordAlert.Visibility = Visibility.Visible;
                passwordAlert.Text = "Password must be at least 10 characters long";
            }
            else
            {
                passwordAlert.Visibility = Visibility.Hidden;
            }

            if (password.Text.Length == 0)
            {
                labelPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
