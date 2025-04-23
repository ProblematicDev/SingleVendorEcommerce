using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.DTO;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products =  await _repository.GetAllAsync();
        var productDtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Sku = p.Sku,
            Price = p.Price
        });
        return productDtos;

    }


    public async Task<ProductDto?> GetProductByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null)
            return null;
        
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Sku = product.Sku,
            Price = product.Price
        };
    }

    public async Task AddProductAsync(ProductDto dto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Price = dto.Price,
            Sku = dto.Sku
        };

        await _repository.AddAsync(product);
    }


    public async Task UpdateProductAsync(ProductDto dto)
    {
        var product = new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Sku = dto.Sku
        };
        await _repository.UpdateAsync(product);

    }

    public async Task DeleteProductAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}