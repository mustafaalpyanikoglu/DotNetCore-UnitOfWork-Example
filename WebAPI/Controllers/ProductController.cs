using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.CategoryService;
using WebAPI.Business.ProductService;
using WebAPI.DataAccess;
using WebAPI.DataAccess.UnitOfWork;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Add()
        {
            _categoryService.Add(new Category()
            {
                Name = "Teknoloji"
            }); //Veri RAM'de tutuluyor
            _productService.Add(new Product()
            {
                Name = "Leptop",
                Price = 1000,
                Quantity = 10,
                CategoryId = 1
            }); //Veri RAM'de tutuluyor
            new UnitOfWork(new UnitOfWorkContext()).SaveChanges();//Veritabanına kaydetme işlemi yapılıyor
            return Ok("Ürün eklendi");
        }
    }
}
