namespace InventoryManagement.Domain.Entities;

public class Product
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public decimal Price { get; set; }
    
    public int QuantityInStock { get; set; }
    
    // Foreign Keys
    
    public Guid CategoryId { get; set; }
    public Guid SupplierId { get; set; }
    

}