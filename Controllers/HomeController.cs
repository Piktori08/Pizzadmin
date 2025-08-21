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
        private readonly IProductService _productService;
        private readonly IOrderProductsService _orderProductsService;

        public HomeController(ILogger<HomeController> logger ,IOrderService orderService, IProductService productService, IOrderProductsService orderProductsService)
        {
            _logger = logger;
            _orderService = orderService;
            _productService = productService;
            _orderProductsService = orderProductsService;
        }

        public async Task<IActionResult> Index(string dateFilter)
        {
            ViewData["active"] = "dashboard";

            ViewBag.ViewDateFilter = dateFilter;

            if (dateFilter != null)
            {
                var filteredOrders = (await _orderService.GetFilteredOrders(dateFilter)).OrderByDescending(o => o.CreatedAt);
                var filteredOrderCount = filteredOrders.Count();
                var filteredRevenue = await _orderService.FilteredRevenue(dateFilter);

                ViewBag.TodayRevenue = filteredRevenue;
                ViewBag.Orders = filteredOrders;
                ViewBag.TodayOrderCount = filteredOrderCount;
            }
            else
            {
                var todaysOrders = (await _orderService.GetTodayOrders()).OrderByDescending(o => o.CreatedAt);
                var todayOrderCount = todaysOrders.Count();
                var todayRevenue = await _orderService.TodayRevenue();

                ViewBag.TodayRevenue = todayRevenue;
                ViewBag.Orders = todaysOrders;
                ViewBag.TodayOrderCount = todayOrderCount;
            }

            var pIds = (await _productService.GetProductsAsync()).Select(p => p.Id).ToList();

            var a = await _orderProductsService.GetMostSoldProduct(pIds);
            var b = await _orderProductsService.GetLeastSoldProduct(pIds);


            ViewBag.MostSoldProduct = await _productService.GetProduct(a.mostSoldProductId);
            ViewBag.MostSoldQuantity = a.maxSold;

            ViewBag.LeastSoldProduct = await _productService.GetProduct(b.minSoldProductId);
            ViewBag.LeastSoldQuantity = b.minSold;

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
