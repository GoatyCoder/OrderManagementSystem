using OrderManagementSystem.Models;
using OrderManagementSystem.ViewModels;
using System.Windows;

namespace OrderManagementSystem.Views
{
    public partial class CategoryManagerView : Window
    {
        private CategoryManagerViewModel _viewModel;
        public CategoryManagerView(CategoryManagerViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
        }

        private void categoriesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedCategory = e.AddedItems[0] as Category;
                categoryNameTextBox.Text = selectedCategory.Name;
            }
        }
    }
}
