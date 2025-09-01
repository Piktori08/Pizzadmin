using Pizzadmin.Data;

namespace Pizzadmin.Repositories
{
    public class NotificationRepository
    {
        private readonly PizzadminContext _context;


        public NotificationRepository(PizzadminContext context)
        {
            _context = context;
        }

        public void Add(string message)
        {
            var notif = new Notifications
            {
                Message = message,
                CreatedAt = DateTime.Now
            };
            _context.Notifications.Add(notif);
            _context.SaveChanges();
        }

        public IEnumerable<Notifications> GetAll()
        {
            return _context.Notifications.OrderByDescending(n => n.CreatedAt).ToList();
        }
    }
}
