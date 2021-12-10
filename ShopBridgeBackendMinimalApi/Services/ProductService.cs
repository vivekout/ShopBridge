using Microsoft.EntityFrameworkCore;
using ShopBridgeBackendMinimalApi.Data;
using ShopBridgeBackendMinimalApi.Models;

namespace ShopBridgeBackendMinimalApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;

        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<List<Product>> Get() =>
            await _productContext.Products.ToListAsync();

        public async Task<Product> Get(int id) =>
            await _productContext.Products.FindAsync(id);

        public async Task<Product> Create(Product product)
        {
            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product updateProduct, int id)
        {
            var product = await _productContext.Products.FindAsync(id);
            if (product is null) return null;
            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(int id)
        {
            var product = await _productContext.Products.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
