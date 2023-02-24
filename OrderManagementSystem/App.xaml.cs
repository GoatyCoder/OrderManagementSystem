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
            UserManagerViewModel viewModel = new UserManagerViewModel(unitOfWork);
            UserManagerView view = new UserManagerView(viewModel);
            view.Show();
        }
    }
}
