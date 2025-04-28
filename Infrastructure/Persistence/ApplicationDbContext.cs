using Microsoft.EntityFrameworkCore;
using Domain.Entities;
// using Infrastructure.Persistence.Configurations;


namespace Infrastructure.Persistence;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ProductCategory> ProductCategorys => Set<ProductCategory>();
    
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<ProductCustomAttribute> ProductCustomAttributes => Set<ProductCustomAttribute>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<User>();
        
        // Optional: Add further config here or via Fluent API classes

        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>(entity =>
        {
             entity.Property(p => p.Name)
                 .HasMaxLength(100); // <-- Set max length here
             
             entity.Property(p => p.Sku)
                 .HasMaxLength(100); // <-- Set max length here
             
        });
        
        modelBuilder.Entity<ProductCustomAttribute>().HasKey(p => p.Id);
        
        modelBuilder.Entity<ProductCustomAttribute>()
            .HasOne(pca => pca.ProductVariant)
            .WithMany(pv => pv.ProductCustomAttributes)
            .HasForeignKey(p => p.ProductVariantId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        modelBuilder.Entity<Customer>(entity =>
        {
             entity.HasKey(e => e.Email);  // Email is PK
             entity.Property(e => e.Email)
                 .HasMaxLength(100)
                 .IsRequired();
        });
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired();
        });

        modelBuilder.Entity<Admin>(entity =>
        {
             entity.HasKey(e => e.Email);  // Email is PK
             entity.Property(e => e.Email)
                 .HasMaxLength(100)
                 .IsRequired();
        });
        
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.UserEmail)
                .HasPrincipalKey(c => c.Email); // Important because Email is PK
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(pm => pm.Id);

            entity.Property(pm => pm.Method)
                .HasMaxLength(50)
                .IsRequired();
        });
        modelBuilder.Entity<CustomerPaymentMethod>(entity =>
        {
            entity.HasKey(e => new { e.UserEmail, e.PaymentMethodId }); // Composite PK with UserEmail

            entity.HasOne(e => e.Customer)
                .WithMany(c => c.CustomerPaymentMethods)
                .HasForeignKey(e => e.UserEmail)  // Use UserEmail
                .HasPrincipalKey(c => c.Email)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.PaymentMethod)
                .WithMany(p => p.CustomerPaymentMethods)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.ToTable("CustomerPaymentMethod");
        });
        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });  // Composite primary key

            entity.HasOne(e => e.Order)
                .WithMany(o => o.OrderProducts)  // Link to the Order class
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Product)
                .WithMany()  // No reverse navigation in Product
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.ToTable("OrderProduct");
        });
        
        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.CategoryId });  // Composite primary key

            // Define the relationship for the Product
            entity.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)  // Link to Product
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);  // Ensure cascading delete

            // Define the relationship for the Category
            entity.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)  // Link to Category
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);  // Ensure cascading delete
        });
        
        modelBuilder.Entity<ProductVariant>()
            .HasOne(v => v.Product)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
    
}