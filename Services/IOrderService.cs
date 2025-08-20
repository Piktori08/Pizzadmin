using Pizzadmin.Data;

namespace Pizzadmin.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrder(int id);
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
        Task<IEnumerable<Order>> GetTodayOrders();
        Task<decimal> TodayRevenue();
        Task<bool> ToggleSeenAsync(int id);
        Task<bool> ToggleCompletedAsync(int id);
        Task<IEnumerable<Order>> GetFilteredOrders(string dateFilter);
        Task<decimal> FilteredRevenue(string dateFilter);
    }
}
