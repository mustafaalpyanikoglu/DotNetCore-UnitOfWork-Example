using WebAPI.Entities;

namespace WebAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UnitOfWorkContext _context;
        public IRepository<Product> ProductRepository { get; private set; }
        public IRepository<Category> CategoryRepository { get; private set; }

        public UnitOfWork(UnitOfWorkContext context)
        {
            _context = context;
            ProductRepository = new GenericRepository<Product>(context);
            CategoryRepository = new GenericRepository<Category>(context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
