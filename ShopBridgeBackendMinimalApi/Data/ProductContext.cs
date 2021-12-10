using Microsoft.EntityFrameworkCore;
using ShopBridgeBackendMinimalApi.Models;

namespace ShopBridgeBackendMinimalApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
