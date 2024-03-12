namespace CoffeeSubscriptionManager.Models
{
    public class GrindSize
    {
        public int Id { get; set; }

        public required string Description { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}