using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;

namespace Pizzadmin.Repositories
{
    public class OrderProductsRepository
    {
        private readonly PizzadminContext _context;
        public OrderProductsRepository(PizzadminContext context)
        {
            _context = context;
        }

        public async Task CreateOrderProducts(int orderId, List<int> productId, List<int> quantities)
        {
            for (int i = 0; i < productId.Count; i++)
            {
                if (quantities[i] > 0)
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = orderId,
                        ProductId = productId[i],
                        Quantity = quantities[i]
                    };
                    await _context.OrderProducts.AddAsync(orderProduct);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteOrderProducts(int orderId)
        {
            var orderProducts = await _context.OrderProducts.Where(op => op.OrderId == orderId).ToListAsync();

            _context.OrderProducts.RemoveRange(orderProducts);
            await _context.SaveChangesAsync();
        }
    }
}