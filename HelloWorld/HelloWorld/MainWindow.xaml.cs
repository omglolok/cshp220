﻿using System;
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
        private Models.User user = new Models.User();
        private static int minLength = 8;

        public MainWindow()
        {
            InitializeComponent();
        }

        public override void EndInit()
        {
            base.EndInit();
            uxContainer.DataContext = user;
        }

        // Maximize window button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else 
            WindowState = WindowState.Maximized;
        }

        // Sign in button click
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }
        // method to check to see whether SignIn button should be enabled
        private void EnableSignIn()
        {
            var usernameLength = username.Text.Length;
            var passwordLength = password.Text.Length;
            if (usernameLength >= minLength && passwordLength >= minLength)
            {
                btnSignIn.IsEnabled = true;
            }
            else btnSignIn.IsEnabled = false;
        }

        // username events
        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
                EnableSignIn();
        }
        private void username_GotFocus(object sender, RoutedEventArgs e)
        {
            labelUsername.Visibility = Visibility.Hidden;
        }
        private void username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (username.Text.Length == 0)
            {
                labelUsername.Visibility = Visibility.Visible;
            }
        }

        // password events
        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
                EnableSignIn();
        }
        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            labelPassword.Visibility = Visibility.Hidden;
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password.Text.Length == 0)
            {
                labelPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
