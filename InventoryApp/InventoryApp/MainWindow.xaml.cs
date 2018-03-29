using InventoryApp.Models;
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
using System.ComponentModel;

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
        }
        #region Member Variables
        private ItemModel selectedItem;
        GridViewColumnHeader _sortColumn = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        #endregion Member Variables


        #region Methods
        private void LoadItems()
        {
            var items = App.InventoryRepository.GetAll();

            uxItemList.ItemsSource = items
                .Select(t => ItemModel.ToModel(t))
                .ToList();
        }
        #endregion Methods
        #region Events
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            string sortBy = column.Tag.ToString();
            uxItemList.Items.SortDescriptions.Clear();

            var sortDescription = new System.ComponentModel.SortDescription(sortBy,
                System.ComponentModel.ListSortDirection.Ascending);
            uxItemList.Items.SortDescriptions.Add(sortDescription);
        }
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ItemWindow();

            if (window.ShowDialog() == true)
            {
                var uiItemModel = window.Item;

                var repositoryItemModel = uiItemModel.ToRepositoryModel();

                App.InventoryRepository.Add(repositoryItemModel);
                LoadItems();
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ItemWindow();
            if (selectedItem != null)
            {
                window.Item = selectedItem.Clone();

                if (window.ShowDialog() == true)
                {
                    App.InventoryRepository.Update(window.Item.ToRepositoryModel());
                    LoadItems();
                }
            }
        }
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.InventoryRepository.Remove(selectedItem.ItemId);
            selectedItem = null;
            LoadItems();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedItem != null);

            //Exercise 1: Enable Delete Menu Item for ContextMenu upon a selection
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }
        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedItem != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }


        private void uxItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = (ItemModel)uxItemList.SelectedValue;
        }

        private void uxItemList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            uxFileChange_Click(sender, null);
        }

        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            {
                GridViewColumnHeader column = (GridViewColumnHeader)e.OriginalSource;
                if (column == null)
                {
                    return;
                }
                if (_sortColumn == column)
                {
                    // Toggle sorting direction 
                    _sortDirection = _sortDirection == ListSortDirection.Ascending ?
                                                       ListSortDirection.Descending :
                                                       ListSortDirection.Ascending;
                }
                else
                {
                    _sortColumn = column;
                    _sortDirection = ListSortDirection.Ascending;
                }
                string columnHeader = string.Empty;
                Binding b = (Binding)_sortColumn.Column.DisplayMemberBinding;
                if (b != null)
                {
                    columnHeader = b.Path.Path;
                }
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxItemList.ItemsSource);
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(columnHeader, _sortDirection));
            }
        }

        #endregion Events
    }
}
