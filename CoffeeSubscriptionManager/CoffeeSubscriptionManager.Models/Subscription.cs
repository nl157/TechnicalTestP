namespace CoffeeSubscriptionManager.Models
{
    public class Subscription
    {
        public required int Id { get; set; }
        public required Customer Customer { get; set; }

        public required int FrequencyInDays { get; set; }

        public required Coffee Coffee { get; set; }

        public required string OrderSize { get; set; }

        public required DateTime NextSendDate { get; set; }

        public required double BaseOrderPrice { get; set; }

        public required string PaymentMethod { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}