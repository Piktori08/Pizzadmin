using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;
using System.Globalization;

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
            if (string.IsNullOrWhiteSpace(dateFilter))
            {
                throw new ArgumentNullException(nameof(dateFilter), "Date filter cannot be null or empty.");
            }

            if (dateFilter.Contains(" to ")) // Safe check for range
            {
                var parts = dateFilter.Split(" to ");
                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid date range format. Expected: yyyy-MM-dd to yyyy-MM-dd");
                }

                var from = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var to = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                return await _context.Orders
                    .Where(o => o.CreatedAt.Date >= from.Date && o.CreatedAt.Date <= to.Date)
                    .ToListAsync();
            }
            else
            {
                var from = DateTime.ParseExact(dateFilter, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                return await _context.Orders
                    .Where(o => o.CreatedAt.Date == from.Date)
                    .ToListAsync();
            }

        }

        public async Task<decimal> FilteredRevenue(string dateFilter)
        {
            if (string.IsNullOrWhiteSpace(dateFilter))
            {
                throw new ArgumentNullException(nameof(dateFilter), "Date filter cannot be null or empty.");
            }

            if (dateFilter.Contains(" to ")) // Safe check for range
            {
                var parts = dateFilter.Split(" to ");
                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid date range format. Expected: yyyy-MM-dd to yyyy-MM-dd");
                }

                var from = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var to = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                return await _context.Orders
                .Where(o => o.CreatedAt.Date >= from.Date && o.CreatedAt.Date <= to.Date)
                .Select(o => o.TotalPrice)
                .SumAsync();
            }
            else
            {
                var from = DateTime.ParseExact(dateFilter, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                return await _context.Orders
                .Where(o => o.CreatedAt.Date == from.Date)
                .Select(o => o.TotalPrice)
                .SumAsync();
            }
        }
        public async Task<int> CountDeliveryOrders(string dateFilter)
        {
            if (string.IsNullOrWhiteSpace(dateFilter))
            {
                return await _context.Orders
                    .Where(o => o.CreatedAt.Date == DateTime.Today && o.Type == "Delivery")
                    .CountAsync();
            }

            if (dateFilter.Contains(" to ")) // Safe check for range
            {
                var parts = dateFilter.Split(" to ");
                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid date range format. Expected: yyyy-MM-dd to yyyy-MM-dd");
                }

                var from = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var to = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                return await _context.Orders
                .Where(o => o.CreatedAt.Date >= from.Date && o.CreatedAt.Date <= to.Date && o.Type == "Delivery")
                .CountAsync();
            }
            else
            {
                var from = DateTime.ParseExact(dateFilter, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                return await _context.Orders
                .Where(o => o.CreatedAt.Date == from.Date && o.Type == "Delivery")
                .CountAsync();
            }
        }
    }
}
