using Pizzadmin.Data;

namespace Pizzadmin.Models
{
    public class OrderForCreation
    {
        public int OrderNumber { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
