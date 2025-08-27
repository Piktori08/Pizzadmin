namespace Pizzadmin.Models
{
    public class OrderForCreationAPI
    {
        public string TotalPrice { get; set; }

        public List<string> ProductIds { get; set; }
        public List<string> Quantities { get; set; }
    }
}
