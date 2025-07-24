namespace Pizzaria.Application.Dtos.Product
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}