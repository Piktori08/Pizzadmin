using Pizzadmin.Data;

namespace Pizzadmin.Models
{
    public class OrderForCreation
    {
        public int OrderNumber { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }

        public List<int> ProductIds { get; set; }
        public List<int> Quantities { get; set; }
    }
}
