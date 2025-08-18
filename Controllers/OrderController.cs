using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Pizzadmin.Data;
using Pizzadmin.Migrations;
using Pizzadmin.Models;
using Pizzadmin.Services;
using System.Threading.Tasks;

namespace Pizzadmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderProductsService _orderProductsService;
        public OrderController(IOrderService orderService, IProductService productService, IOrderProductsService orderProductsService)
        {
            _orderService = orderService;
            _productService = productService;
            _orderProductsService = orderProductsService;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync();
            ViewData["active"] = "orders";
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new OrderForCreation
            {
                Products = await _productService.GetProductsAsync()
            };

            ViewData["active"] = "orders";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] OrderForCreation model)
        {
            var productIds = model.ProductIds.Select(int.Parse).ToList();
            var quantities = model.Quantities.Select(int.Parse).ToList();

            var order = new Order
            {
                TotalPrice = decimal.Parse(model.TotalPrice),
            };
            await _orderService.AddOrder(order);
            
            order.OrderNumber = $"Order_{order.Id}";
            await _orderService.UpdateOrder(order);
            
            await _orderProductsService.CreateOrderProducts(order.Id, productIds, quantities);

            return Ok(new { success = true, message = "Order processed.", redirectUrl = "/Order/Index" });
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _orderProductsService.DeleteOrderProducts(id);
            await _orderService.DeleteOrder(id);

            return RedirectToAction("Index");
        }
    }
}
