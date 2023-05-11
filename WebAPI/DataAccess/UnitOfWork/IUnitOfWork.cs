using WebAPI.Entities;

namespace WebAPI.DataAccess.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepository<Product> ProductRepository { get;}
        public IRepository<Category> CategoryRepository { get;}

        int SaveChanges();
    }
}
