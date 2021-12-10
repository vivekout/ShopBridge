using ShopBridgeBackendMinimalApi.Models;

namespace ShopBridgeBackendMinimalApi.Services
{
    public interface IProductService
    {
        public Task<List<Product>> Get();
        public Task<Product> Get(int id);
        public Task<Product> Create(Product product);
        public Task<Product> Update(Product product, int id);
        public Task<Product> Remove(int id);

    }
}
