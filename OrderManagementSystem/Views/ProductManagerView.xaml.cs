using OrderManagementSystem.Models;
using OrderManagementSystem.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OrderManagementSystem.Views
{
    public partial class ProductManagerView : Window
    {
        private readonly ProductManagerViewModel _viewModel;
        public ProductManagerView(ProductManagerViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
        }

        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedProduct = e.AddedItems[0] as Product;
                codeTextBox.Text = selectedProduct.Code;
                nameTextBox.Text = selectedProduct.Name;
                priceTextBox.Text = selectedProduct.Price.ToString();
                //TODO il prezzo deve essere solo un numero
                descriptionTextBox.Text = selectedProduct.Description;
                categoryComboBox.SelectedItem = selectedProduct.Category;
            }
        }
    }
}
