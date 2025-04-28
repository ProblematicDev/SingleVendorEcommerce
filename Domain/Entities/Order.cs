namespace Domain.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Customer Customer { get; set; }
    public string UserEmail { get; set; } 
    
    
    public ICollection<OrderProduct> OrderProducts { get; set; }
    
}