using OrderManagementSystem.Models;
using OrderManagementSystem.ViewModels;
using System.Windows;

namespace OrderManagementSystem.Views
{
    public partial class UserManagerView : Window
    {
        private UserManagerViewModel _viewModel;
        public UserManagerView(UserManagerViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
        }

        private void UsersListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedUser = e.AddedItems[0] as User;
                firstNameTextBox.Text = selectedUser.FirstName;
                lastNameTextBox.Text = selectedUser.LastName;
                emailTextBox.Text = selectedUser.Email;
            }
        }
    }
}
