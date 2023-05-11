using System.Linq.Expressions;

namespace WebAPI.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
