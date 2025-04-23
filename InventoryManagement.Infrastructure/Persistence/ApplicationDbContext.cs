using Microsoft.EntityFrameworkCore;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Persistence.Configurations;


namespace InventoryManagement.Infrastructure.Persistence;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        // Optional: Add further config here or via Fluent API classes
    }
    
}