namespace Domain.Entities;

public class ProductCategory
{
    public Guid CategoryId { get; set; }
    public Guid ProductId { get; set; }
    public Product Product  { get; set; }
    public Category Category  { get; set; } 
    
}