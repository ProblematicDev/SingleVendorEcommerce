namespace Domain.Entities;

public class Product
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
    public int QuantityInStock { get; set; }
    
    public decimal Weight { get; set; }
    
    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<ProductVariant> ProductVariants { get; set; }
    
    // Foreign Keys
}