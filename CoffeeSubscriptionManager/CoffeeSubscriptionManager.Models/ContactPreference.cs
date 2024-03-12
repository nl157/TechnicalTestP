namespace CoffeeSubscriptionManager.Models
{
    public class ContactPreference
    {
        public int Id { get; set; }

        public bool SMS { get; set; }

        public bool Email { get; set; }

        public bool Mail { get; set; }
    }
}