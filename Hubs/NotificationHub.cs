using Microsoft.AspNetCore.SignalR;

namespace Pizzadmin.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task NewOrderPlaced(string orderId)
        {
            await Clients.All.SendAsync("ReceiveNotification", $" A new order #{orderId} has been created!");
        }
    }
}
