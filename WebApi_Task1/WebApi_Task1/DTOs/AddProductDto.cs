namespace WebApi_Task1.DTOs
{
    public class AddProductDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
