// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using Domain.Entities;
//
// namespace Infrastructure.Persistence.Configurations;

// public class ProductConfiguration : IEntityTypeConfiguration<Product>
// {
//     public void Configure(EntityTypeBuilder<Product> builder)
//     {
//         builder.HasKey(p => p.Id);
//         builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
//         builder.Property(p => p.Sku).IsRequired().HasMaxLength(50);
//     }
// }