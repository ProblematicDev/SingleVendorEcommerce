using Application.DTO;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest createProductRequest)
    {

        var productDto = new ProductDto
        {
            Id = Guid.NewGuid(),
            Name = createProductRequest.Name,
            Price = createProductRequest.Price,
            Sku = createProductRequest.Sku

        };
        
        await _productService.AddProductAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequest updateProductRequest)
    {
        
        var productDto = new ProductDto
        {
            Id = id,
            Name = updateProductRequest.Name,
            Price = updateProductRequest.Price,
            Sku = updateProductRequest.Sku

        };
        
        
        await _productService.UpdateProductAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}