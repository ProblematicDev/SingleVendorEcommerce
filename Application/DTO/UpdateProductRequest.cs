namespace Application.DTO;

public class UpdateProductRequest
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Sku { get; set; } = default!;
}