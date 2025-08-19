using Microsoft.AspNetCore.Mvc;
using Pizzadmin.Data;
using Pizzadmin.Models;
using Pizzadmin.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace Pizzadmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger ,IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["active"] = "dashboard";
            var todaysOrders = await _orderService.GetTodayOrders();
            var todayOrderCount = todaysOrders.Count();
            var todayRevenue = await _orderService.TodayRevenue();
            ViewBag.TodayRevenue = todayRevenue;
            ViewBag.Orders = todaysOrders;
            ViewBag.TodayOrderCount = todayOrderCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
