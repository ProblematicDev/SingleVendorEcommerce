namespace Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } 
    
    public ICollection<ProductCategory> ProductCategories { get; set; }
}