using Pizzadmin.Data;
using Pizzadmin.Repositories;

namespace Pizzadmin.Services
{
    public class NotificationService : INotificationService
    {
        public readonly NotificationRepository _context;
        public NotificationService(NotificationRepository context)
        {
            _context = context;
        }
        public void Add(string message)
        {
            _context.Add(message);
        }
        public IEnumerable<Notifications> GetAll()
        {
            return _context.GetAll();
        }
    }
}
