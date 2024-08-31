namespace WebApi_Task1.DTOs
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
