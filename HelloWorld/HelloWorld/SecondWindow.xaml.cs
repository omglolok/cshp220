using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private ListSortDirection _sortDirection;
        private GridViewColumnHeader _sortColumn;
        public SecondWindow()
        {
            InitializeComponent();

            // create a list of users to show up on List View Control
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "z2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });
            users.Add(new Models.User { Name = "Jimmy", Password = "aVeryBadPassword" });

            uxList.ItemsSource = users;
        }

        private void uxList_OnColumnClick(object sender, RoutedEventArgs e)
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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(columnHeader, _sortDirection));
        }
    }
}
