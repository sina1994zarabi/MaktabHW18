namespace ECommerce.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}