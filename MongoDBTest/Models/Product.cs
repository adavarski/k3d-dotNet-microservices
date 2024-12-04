using System.ComponentModel.DataAnnotations;

namespace MongoDBTest.Models
{
    public class Product
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
    }
}
