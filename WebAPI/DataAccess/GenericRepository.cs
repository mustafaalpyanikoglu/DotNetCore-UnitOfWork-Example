using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.DataAccess
{
    public class GenericRepository<T> : IRepository<T>
                where T : Entity
    {
        private UnitOfWorkContext _context;

        public GenericRepository(UnitOfWorkContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(int id)
        {
            var currentEntity = _context.Set<T>().SingleOrDefault(z => z.Id == id);
            _context.Set<T>().Remove(currentEntity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _context.Set<T>().ToList() : _context.Set<T>().Where(filter).ToList();

        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
