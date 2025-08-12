using Microsoft.AspNetCore.Mvc;
using Pizzadmin.Data;
using Pizzadmin.Models;
using Pizzadmin.Services;

namespace Pizzadmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync();
            ViewData["active"] = "orders";
            return View(orders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = ;

            ViewData["active"] = "orders";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderForCreation model)
        {
            
            await _orderService.AddOrder(model);
            return RedirectToAction("Index");


        }
               
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
