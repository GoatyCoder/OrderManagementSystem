using OrderManagementSystem.Models.Repositories;

namespace OrderManagementSystem.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<User> UserManager { get; }
        public IRepository<Category> CategoryManager { get; }
        public IRepository<Product> ProductManager {get; }
        public IRepository<Order> OrderManager {get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserManager = new Repository<User>(_context);
            CategoryManager = new Repository<Category>(_context);
            ProductManager = new Repository<Product>(_context);
            OrderManager = new Repository<Order>(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
