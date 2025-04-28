namespace Application.DTO;

public class ProductDto
{
    
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Sku { get; set; } = default!;
}