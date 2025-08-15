using Pizzadmin.Data;

namespace Pizzadmin.Services
{
    public interface IOrderProductsService
    {
        Task CreateOrderProducts (int orderId, List<int> productId, List<int> quantities);
    }
}