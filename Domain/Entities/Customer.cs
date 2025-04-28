namespace Domain.Entities;

public class Customer : User
{
    public ICollection<Order> Orders { get; set; }
    public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
}