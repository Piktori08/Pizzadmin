using Pizzadmin.Repositories;
using Pizzadmin.Data;
using Microsoft.EntityFrameworkCore;

namespace Pizzadmin.Services
{
    public class OrderProductsService : IOrderProductsService
    {
        private readonly OrderProductsRepository _context;

        public OrderProductsService(OrderProductsRepository context)
        {
            _context = context;
        }

        public async Task CreateOrderProducts (int orderId, List<int> productId, List<int> quantities)
        {
            await _context.CreateOrderProducts(orderId, productId, quantities);
        }
    }
}