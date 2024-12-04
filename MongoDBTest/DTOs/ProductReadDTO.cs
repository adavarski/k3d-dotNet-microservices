namespace MongoDBTest.DTOs
{
    public class ProductReadDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
        public int ProductId { get; set; }
    }
}
