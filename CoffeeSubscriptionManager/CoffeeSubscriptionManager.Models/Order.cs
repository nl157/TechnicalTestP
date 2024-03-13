
namespace CoffeeSubscriptionManager.Models
{
    public class Order
    {

        public required int Id { get; set; }
        public required Subscription Subscription { get; set; }
        public DateTime? ScheduledSendDate { get; set; }
        public bool IsSent { get; set; }
        public double Price { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
