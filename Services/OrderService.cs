using Pizzadmin.Data;
using Pizzadmin.Repositories;

namespace Pizzadmin.Services
{
    public class OrderService : IOrderService
    {
        public readonly OrderRepository _context;
        public OrderService(OrderRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.GetAsync(id);
        }

        public async Task AddOrder(Order order)
        {
            await _context.AddAsync(order);
        }

        public async Task UpdateOrder(Order order)
        {
            await _context.UpdateAsync(order);
        }

        public async Task DeleteOrder(int id)
        {
            await _context.RemoveAsync(id);
        }

        public async Task<IEnumerable<Order>> GetTodayOrders()
        {
            return await _context.GetTodayOrders();
        }

        public async Task<decimal> TodayRevenue()
        {
            return await _context.TodayRevenue();
        }
        public async Task<bool> ToggleSeenAsync(int id)
        {
            return await _context.ToggleSeenAsync(id);
        }
        public async Task<bool> ToggleCompletedAsync(int id)
        {
            return await _context.ToggleCompletedAsync(id);
        }
    }
}