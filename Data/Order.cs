namespace Pizzadmin.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string? OrderNumber { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
