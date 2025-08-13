using Microsoft.AspNetCore.Mvc;
using Pizzadmin.Data;
using Pizzadmin.Models;
using Pizzadmin.Services;
using System.Threading.Tasks;

namespace Pizzadmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
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
        public async Task<IActionResult> Create(OrderForCreation model)
        {
            //var order = new Order
            //{
            //    OrderNumber = model.OrderNumber,
            //    TotalPrice = 200
            //};

            //await _orderService.AddOrder(order);
            return RedirectToAction("Index");
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
