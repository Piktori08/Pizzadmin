using Pizzadmin.Data;

namespace Pizzadmin.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private readonly PizzadminContext _context;
        public OrderRepository(PizzadminContext context) : base(context)
        {
            _context = context;
        }
    }
}
