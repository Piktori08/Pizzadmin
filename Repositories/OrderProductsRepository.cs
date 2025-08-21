using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;
using Pizzadmin.Migrations;

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

        public async Task<(int maxSold, int mostSoldProductId)> GetMostSoldProduct(List<int> productIds)
        {
            var list = new List<int[]>();

            foreach (var p in productIds)
            {
                var q = await _context.OrderProducts.Where(op => op.ProductId == p).Select(op => op.Quantity).ToListAsync();
                var sold = q.Sum();
                var productId = await _context.Products.Where(pr => pr.Id == p).Select(pr => pr.Id).FirstOrDefaultAsync();

                list.Add(new int[] { sold, productId });
            }


            int maxSold = int.MinValue;
            int mostSoldProductId = -1;

            foreach (var item in list)
            {
                int sold = item[0];
                int productId = item[1];

                if (sold > maxSold)
                {
                    maxSold = sold;
                    mostSoldProductId = productId;
                }
            }

            return (maxSold, mostSoldProductId);
        }

        public async Task<(int minSold, int minSoldProductId)> GetLeastSoldProduct(List<int> productIds)
        {
            var list = new List<int[]>();

            foreach (var p in productIds)
            {
                var q = await _context.OrderProducts.Where(op => op.ProductId == p).Select(op => op.Quantity).ToListAsync();
                var sold = q.Sum();
                var productId = await _context.Products.Where(pr => pr.Id == p).Select(pr => pr.Id).FirstOrDefaultAsync();

                list.Add(new int[] { sold, productId });
            }


            int minSold = int.MaxValue;
            int minSoldProductId = -1;

            foreach (var item in list)
            {
                int sold = item[0];
                int productId = item[1];

                if (sold < minSold)
                {
                    minSold = sold;
                    minSoldProductId = productId;
                }
            }

            return (minSold, minSoldProductId);
        }
        public async Task<List<OrderProduct>> ViewReceipt(int orderId)
        {
            return await _context.OrderProducts
                .Where(op => op.OrderId == orderId)
                .Include(op => op.Product)
                .ToListAsync();
        }
    }
}