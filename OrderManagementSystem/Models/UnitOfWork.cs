using OrderManagementSystem.Models.Repositories;

namespace OrderManagementSystem.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<User> UserManager { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserManager = new Repository<User>(_context);
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
