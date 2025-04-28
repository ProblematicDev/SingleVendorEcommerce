namespace Domain.Entities;

public class ProductCustomAttribute
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string AttributeName { get; set; } = string.Empty;
    public string AttributeValue { get; set; } = string.Empty;
    
    public Guid ProductVariantId { get; set; }
    public ProductVariant ProductVariant;


}