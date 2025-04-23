namespace InventoryManagement.Domain.Entities;

public enum TransactionType
{
    StockIn,
    StockOut
}

public class InventoryTransaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public int QuantityChanged { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public TransactionType Type { get; set; }
    public string? Notes { get; set; }
}
