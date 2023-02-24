using OrderManagementSystem.Models.Repositories;
using System;

namespace OrderManagementSystem.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserManager { get; }

        int Save();
    }
}
