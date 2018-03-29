using InventoryApp.Models;
using System;
using System.Windows;

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        public ItemWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Item != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Item = new ItemModel();
                Item.ItemCreationDate = DateTime.Now;
            }

            uxGrid.DataContext = Item;

        }
        public ItemModel Item { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}