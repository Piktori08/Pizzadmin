using Pizzadmin.Data;

namespace Pizzadmin.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly PizzadminContext _context;
        public ProductRepository(PizzadminContext context) : base(context)
        {
            _context = context;
        }
    }
}
