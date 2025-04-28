namespace Domain.Entities;

public class CustomerPaymentMethod
{
    public string UserEmail { get; set; }  // Changed to UserEmail
    public Customer Customer { get; set; }

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    // Extra fields
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}