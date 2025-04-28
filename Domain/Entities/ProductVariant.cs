namespace Domain.Entities;

public class ProductVariant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string VariantName { get; set; }
    public Guid ProductId { get; set; }

    // Navigation property to the related Product
    public Product Product { get; set; }
    public ICollection<ProductCustomAttribute> ProductCustomAttributes { get; } = new List<ProductCustomAttribute>();
}