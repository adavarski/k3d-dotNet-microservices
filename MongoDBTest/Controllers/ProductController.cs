using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDBTest.Data;
using MongoDBTest.DTOs;
using MongoDBTest.Models;

namespace MongoDBTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetPlatforms()
        {
            Console.WriteLine("---> Getting Products....");

            var platforms = _repository.GetProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDTO>>(platforms));
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDTO>> CreateProduct(ProductCreateDTO product)
        {
            Console.WriteLine("---> Creating Product....");
            if (product == null)
            {
                return ValidationProblem("You cannot sent an empty object");
            }

            product.ProductId = _repository.ProductsCount() + 1;

            var productModel = _mapper.Map<Product>(product);

            _repository.CreateProduct(productModel);

            _repository.SaveChanges();

            var displayAddedProduct = _mapper.Map<ProductReadDTO>(productModel);


            return CreatedAtRoute(nameof(GetProductById), new { Id = displayAddedProduct.ProductId }, displayAddedProduct);
        }

        [HttpGet("{productId}", Name = "GetProductById")]
        public ActionResult<ProductReadDTO> GetProductById(int productId)
        {
            var product = _repository.GetProductById(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductReadDTO>(product));
        }
    }
}
