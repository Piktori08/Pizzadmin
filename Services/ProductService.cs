using Pizzadmin.Data;
using Pizzadmin.Repositories;

namespace Pizzadmin.Services
{
    public class ProductService : IProductService
    {
        public readonly ProductRepository _context;
        public ProductService(ProductRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.GetAsync(id);
        }

        public async Task AddProduct(Product product)
        {
            await _context.AddAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _context.UpdateAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _context.RemoveAsync(id);
        }
    }
}
