using Microsoft.AspNetCore.Mvc;
using Pizzadmin.Data;
using Pizzadmin.Models;
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

        [HttpPost("addOrder")]
        //-- fetch('https://localhost:44365/api/Pizzadmin/orders')
        public async Task<IActionResult> AddOrder([FromBody] OrderForCreationAPI model)
        {
            var productIds = model.ProductIds.Select(int.Parse).ToList();
            var quantities = model.Quantities.Select(int.Parse).ToList();

            var order = new Order
            {
                TotalPrice = decimal.Parse(model.TotalPrice),
                Type = "Delivery"
            };
            await _orderService.AddOrder(order);

            order.OrderNumber = $"Order_{order.Id}";
            await _orderService.UpdateOrder(order);

            await _orderProductsService.CreateOrderProducts(order.Id, productIds, quantities);
            return Ok(new { success = true, message = "Order processed." });
        }
    }
}
