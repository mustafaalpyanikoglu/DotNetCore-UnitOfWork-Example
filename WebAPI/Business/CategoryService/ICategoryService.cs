using WebAPI.DataAccess;
using WebAPI.DataAccess.UnitOfWork;
using WebAPI.Entities;

namespace WebAPI.Business.CategoryService
{
    public interface ICategoryService
    {
        void Add(Category category);
    }
    public class CategoryManager : ICategoryService
    {
        public void Add(Category category)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new UnitOfWorkContext());
            unitOfWork.CategoryRepository.Add(category);
        }
    }
}
