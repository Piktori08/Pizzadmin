using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;

namespace Pizzadmin.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private readonly PizzadminContext _context;
        public OrderRepository(PizzadminContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetTodayOrders()
        {
            return await _context.Orders
                .Where(o => o.CreatedAt.Date == DateTime.Now.Date)
                .ToListAsync();
        }
        public async Task<decimal> TodayRevenue()
        {
            return await _context.Orders
                .Where(o => o.CreatedAt.Date == DateTime.Now.Date)
                .Select(o => o.TotalPrice)
                .SumAsync();
        }
        public async Task<bool> ToggleSeenAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            order.IsSeen = !order.IsSeen;
            await _context.SaveChangesAsync();
            return order.IsSeen;
        }

        public async Task<bool> ToggleCompletedAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            order.IsCompleted = !order.IsCompleted;
            await _context.SaveChangesAsync();
            return order.IsCompleted;
        }

        public async Task<IEnumerable<Order>> GetFilteredOrders(string dateFilter)
        {
            var dateFilterNew = dateFilter;

            var dateFrom = dateFilter?.Substring(0, 10);
            var dateTo = dateFilterNew?.Substring(14, 10);

            var from = DateTime.Parse(dateFrom);
            var to = DateTime.Parse(dateTo);

            return await _context.Orders
                .Where(o => o.CreatedAt.Date >= from.Date && o.CreatedAt.Date <= to.Date)
                .ToListAsync();
        }

        public async Task<decimal> FilteredRevenue(string dateFilter)
        {
            var dateFilterNew = dateFilter;

            var dateFrom = dateFilter?.Substring(0, 10);
            var dateTo = dateFilterNew?.Substring(14, 10);

            var from = DateTime.Parse(dateFrom);
            var to = DateTime.Parse(dateTo);

            return await _context.Orders
                .Where(o => o.CreatedAt.Date >= from.Date && o.CreatedAt.Date <= to.Date)
                .Select(o => o.TotalPrice)
                .SumAsync();
        }
    }
}
