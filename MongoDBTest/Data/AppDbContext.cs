using MongoDBTest.Models;
using MongoFramework;

namespace MongoDBTest.Data
{
    public class AppDbContext : MongoDbContext
    {
        public AppDbContext(IMongoDbConnection connection) : base(connection) { }

        public MongoDbSet<Product> Products { get; set; }
    }
}
