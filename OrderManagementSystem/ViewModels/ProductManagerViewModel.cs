using OrderManagementSystem.Command;
using OrderManagementSystem.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace OrderManagementSystem.ViewModels
{
    public class ProductManagerViewModel : ViewModelBase
    {
        private string _productCode;
        private string _productName;
        private string _productDescription;
        private double _productPrice;
        private Category _productCategory;
        private Product _selectedProduct;
        private BindingList<Product> _products;
        private BindingList<Category> _categories;

        public ProductManagerViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Categories = new BindingList<Category>((System.Collections.Generic.IList<Category>)unitOfWork.CategoryManager.GetAll());
            Products = new BindingList<Product>((System.Collections.Generic.IList<Product>)unitOfWork.ProductManager.GetAll());
        }

        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                SetProperty(ref _productCode, value);
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set { SetProperty(ref _productDescription, value); }
        }

        public double ProductPrice
        {
            get { return _productPrice; }
            set { SetProperty(ref _productPrice, value); }
        }

        public Category ProductCategory
        {
            get { return _productCategory; }
            set { SetProperty(ref _productCategory, value); }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetProperty(ref _selectedProduct, value); }
        }

        public BindingList<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public BindingList<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }

        }


        public ICommand AddProductCommand => new RelayCommand(AddProduct, CanAddProduct);
        public ICommand RemoveProductCommand => new RelayCommand(RemoveProduct, CanRemoveProduct);
        public ICommand EditProductCommand => new RelayCommand(EditProduct, CanEditProduct);

        private void AddProduct()
        {
            Product newProduct = new Product() { Code = ProductCode, Name = ProductName, Description = ProductDescription, Price = ProductPrice, Category = ProductCategory };
            unitOfWork.ProductManager.Add(newProduct);
            unitOfWork.Save();

            _products.Add(newProduct);
            ClearForm();
        }

        private bool CanAddProduct()
        {
            return !string.IsNullOrWhiteSpace(ProductCode)
                && !string.IsNullOrWhiteSpace(ProductName)
                && ProductPrice >= 0
                && ProductCategory != null;
        }

        private void RemoveProduct()
        {
            if (SelectedProduct != null)
            {
                unitOfWork.ProductManager.Remove(SelectedProduct);
                unitOfWork.Save();

                _products.Remove(SelectedProduct);
                ClearForm();
            }
        }

        private bool CanRemoveProduct()
        {
            return SelectedProduct != null;
        }

        private void EditProduct()
        {
            if (SelectedProduct != null)
            {
                if (ProductCode != SelectedProduct.Code)
                    SelectedProduct.Code = ProductCode;
                if (ProductName != SelectedProduct.Name)
                    SelectedProduct.Name = ProductName;
                if (ProductDescription != SelectedProduct.Description)
                    SelectedProduct.Description = ProductDescription;
                if (ProductPrice != SelectedProduct.Price)
                    SelectedProduct.Price = ProductPrice;
                if (ProductCategory != SelectedProduct.Category)
                    SelectedProduct.Category = ProductCategory;

                unitOfWork.Save();

                int index = Products.IndexOf(SelectedProduct);
                if (index >= 0)
                {
                    Products.ResetItem(index);
                }

                ClearForm();
            }
        }

        private bool CanEditProduct()
        {
            return (SelectedProduct != null)
                && !string.IsNullOrWhiteSpace(ProductCode)
                && !string.IsNullOrWhiteSpace(ProductName)
                && ProductPrice >= 0
                && ProductCategory != null;
        }

        private void ClearForm()
        {
            this.ProductCode = string.Empty;
            this.ProductName = string.Empty;
            this.ProductDescription = string.Empty;
            this.ProductPrice = double.NaN;
            this.ProductCategory = null;
            this.SelectedProduct = null;

        }
    }
}
