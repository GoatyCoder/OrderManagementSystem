using OrderManagementSystem.Models.Repositories;
using System;

namespace OrderManagementSystem.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserManager { get; }
        IRepository<Category> CategoryManager { get; }
        IRepository<Product> ProductManager { get; }
        IRepository<Order> OrderManager { get; }

        int Save();
    }
}
