using Microsoft.EntityFrameworkCore;
namespace Pizzadmin.Data
{
    public class PizzadminContext : DbContext
    {
        public PizzadminContext(DbContextOptions<PizzadminContext> options) : base(options) { }
    }
}