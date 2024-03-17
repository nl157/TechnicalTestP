namespace CoffeeSubscriptionManager.Models
{
    public class Coffee
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public DateTime? DeletedDate { get; set;}
    }
}