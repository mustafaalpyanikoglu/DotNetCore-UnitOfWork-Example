using WebAPI.DataAccess.UnitOfWork;
using WebAPI.DataAccess;
using WebAPI.Entities;

namespace WebAPI.Business.ProductService
{
    public interface IProductService
    {
        void Add(Product product);
    }
    public class ProductManager : IProductService
    {
        public void Add(Product product)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new UnitOfWorkContext());
            unitOfWork.ProductRepository.Add(product);
        }
    }
}
