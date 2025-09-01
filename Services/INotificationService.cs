using Pizzadmin.Data;

namespace Pizzadmin.Services
{
    public interface INotificationService
    {
        public void Add(string message);
        IEnumerable<Notifications> GetAll();
    }
}
