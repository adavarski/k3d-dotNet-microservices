using MongoDB.Driver;
using MongoDBTest.DTOs;
using MongoDBTest.Models;

namespace MongoDBTest.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            
            _context.Products.Add(product);
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
            _context.SaveChanges();

            return true;
        }

        public int ProductsCount()
        {
            return _context.Products.Count();
        }
    }
}
