namespace Pizzadmin.Models
{
    public class NotificationsModel
    {
        public int Id { get; set; }
        public string ?Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
