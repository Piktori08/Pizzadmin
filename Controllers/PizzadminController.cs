using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Pizzadmin.Data;
using Pizzadmin.Hubs;
using Pizzadmin.Models;
using Pizzadmin.Services;

[Route("api/[controller]")]
public class PizzadminController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly IOrderProductsService _orderProductsService;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly INotificationService _notificationService;

    public PizzadminController(
        IOrderService orderService,
        IProductService productService,
        IOrderProductsService orderProductsService,
        IHubContext<NotificationHub> hubContext,
        INotificationService notificationService)
    {
        _orderService = orderService;
        _productService = productService;
        _orderProductsService = orderProductsService;
        _hubContext = hubContext;
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Index()
    {
        var products = await _productService.GetProductsAsync();
        return products;
    }

    [HttpPost("addOrder")]
    public async Task<IActionResult> AddOrder([FromBody] OrderForCreationAPI model)
    {
        try
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

            // ---------------------------
            // 🔹 Notification Logic
            // ---------------------------
            string message = $"A new order {order.OrderNumber} has been created! Total: ${order.TotalPrice:F2}";

            // 1️⃣ Save notification to database
            _notificationService.Add(message);

            // 2️⃣ Send real-time notification via SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            // ---------------------------

            return Ok(new { success = true, message = "Order processed.", orderId = order.OrderNumber });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = "Error processing order: " + ex.Message });
        }
    }

    // Optional: endpoint to fetch all saved notifications
    [HttpGet("notifications")]
    public IActionResult GetNotifications()
    {
        var notifications = _notificationService.GetAll();
        return Ok(notifications);
    }
}
