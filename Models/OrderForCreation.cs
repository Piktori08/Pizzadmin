using Pizzadmin.Data;

namespace Pizzadmin.Models
{
    public class OrderForCreation
    {
        public IEnumerable<Product> Products { get; set; }
        public string TotalPrice { get; set; }

        public List<string> ProductIds { get; set; }
        public List<string> Quantities { get; set; }
    }
}
