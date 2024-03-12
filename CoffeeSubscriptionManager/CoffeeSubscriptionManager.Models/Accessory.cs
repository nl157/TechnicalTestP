namespace CoffeeSubscriptionManager.Models
{
    public class Accessory
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public double Price { get; set; }

        public int StockCount { get; set; }
    }
}