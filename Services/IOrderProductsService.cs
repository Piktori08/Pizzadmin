using Pizzadmin.Data;

namespace Pizzadmin.Services
{
    public interface IOrderProductsService
    {
        Task CreateOrderProducts (int orderId, List<int> productId, List<int> quantities);
        Task DeleteOrderProducts(int orderId);
        Task<(int maxSold, int mostSoldProductId)> GetMostSoldProduct(List<int> productIds);
        Task<(int minSold, int minSoldProductId)> GetLeastSoldProduct(List<int> productIds);
    }
}