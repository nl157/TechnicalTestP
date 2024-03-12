namespace CoffeeSubscriptionManager.Models
{
    public class CoffeeBatch
    {
        public int Id { get; set; }

        public required Coffee Coffee { get; set; }
        public int BatchNumber { get; set; }
        public required List<GrindSize> GrindSizesAvailable { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime BatchDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}