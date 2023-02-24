using OrderManagementSystem.Command;
using OrderManagementSystem.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace OrderManagementSystem.ViewModels
{
    public class CategoryManagerViewModel : ViewModelBase
    {
        private string _categoryName;
        private Category _selectedCategory;
        private BindingList<Category> _categories;

        public CategoryManagerViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Categories = new BindingList<Category>((System.Collections.Generic.IList<Category>)unitOfWork.CategoryManager.GetAll());
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { SetProperty(ref _categoryName, value); }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }

        public BindingList<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        public ICommand AddCategoryCommand => new RelayCommand(AddCategory);
        public ICommand RemoveCategoryCommand => new RelayCommand(RemoveCategory);
        public ICommand EditCategoryCommand => new RelayCommand(EditCategory);

        private void AddCategory()
        {
            Category newCategory = new Category() { Name = CategoryName };
            unitOfWork.CategoryManager.Add(newCategory);
            unitOfWork.Save();

            Categories.Add(newCategory);
            ClearForm();

        }

        private void RemoveCategory()
        {
            if (SelectedCategory != null)
            {
                unitOfWork.CategoryManager.Remove(SelectedCategory);
                unitOfWork.Save();
                Categories.Remove(SelectedCategory);

                ClearForm();
            }
        }

        private void EditCategory()
        {
            if (SelectedCategory != null)
            {
                if (this.CategoryName != SelectedCategory.Name)
                    SelectedCategory.Name = this.CategoryName;

                unitOfWork.Save();

                int index = Categories.IndexOf(SelectedCategory);
                if (index >= 0)
                {
                    Categories.ResetItem(index);
                }

                ClearForm();
            }
        }

        private void ClearForm()
        {
            this.CategoryName = string.Empty;
            this.SelectedCategory = null;
        }
    }
}
