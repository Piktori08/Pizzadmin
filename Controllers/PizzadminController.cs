using Microsoft.AspNetCore.Mvc;
using Pizzadmin.Data;
using Pizzadmin.Services;

namespace Pizzadmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzadminController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderProductsService _orderProductsService;

        public PizzadminController(IOrderService orderService, IProductService productService, IOrderProductsService orderProductsService)
        {
            _orderService = orderService;
            _productService = productService;
            _orderProductsService = orderProductsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Index()
        {
            var products = await _productService.GetProductsAsync();
            return products;
        }

        [HttpGet("addOrder")]
        //-- fetch('https://localhost:44365/api/Pizzadmin/orders')
        public async Task<IEnumerable<Order>> AddOrder()
        {
            var orders = await _orderService.GetOrdersAsync();
            return orders;
        }
    }
}
