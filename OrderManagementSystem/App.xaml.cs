using OrderManagementSystem.Models;
using OrderManagementSystem.ViewModels;
using OrderManagementSystem.Views;
using System.Windows;

namespace OrderManagementSystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationDbContext context = new ApplicationDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(context);

            UserManagerViewModel userViewModel = new UserManagerViewModel(unitOfWork);
            UserManagerView userView = new UserManagerView(userViewModel);

            CategoryManagerViewModel categoryViewModel = new CategoryManagerViewModel(unitOfWork);
            CategoryManagerView categoryView = new CategoryManagerView(categoryViewModel);

            ProductManagerViewModel productViewModel = new ProductManagerViewModel(unitOfWork);
            ProductManagerView productView = new ProductManagerView(productViewModel);

            userView.Show();
            categoryView.Show();
            productView.Show();
        }
    }
}
