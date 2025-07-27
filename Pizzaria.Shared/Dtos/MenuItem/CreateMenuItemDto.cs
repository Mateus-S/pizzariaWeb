namespace Pizzaria.Shared.DTOs.Product
{
    public class CreateMenuItemDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }

}