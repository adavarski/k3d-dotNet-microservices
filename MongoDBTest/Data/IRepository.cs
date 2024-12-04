using MongoDBTest.DTOs;
using MongoDBTest.Models;

namespace MongoDBTest.Data
{
    public interface IRepository
    {
        bool SaveChanges();
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        void CreateProduct(Product product);
        int ProductsCount();
    }
}
