namespace Domain.Entities;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public string Method { get; set; } = String.Empty;
    public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
}