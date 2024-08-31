namespace WebApi_Task1.DTOs
{
    public class UpdateProductDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
