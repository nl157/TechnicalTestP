using System.ComponentModel.DataAnnotations;

namespace CoffeeSubscriptionManager.Models
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string FirstLineOfAddress { get; set; }
        public string? SecondLineOfAddress { get; set; }
        public required string City { get; set; }
        public required string Postcode { get; set; }
        public List<Subscription>? Subscriptions { get; set; }
        public required List<ContactPreference> ContactPreferences { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}