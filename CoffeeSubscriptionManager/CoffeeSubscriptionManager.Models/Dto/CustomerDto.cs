

using System.ComponentModel.DataAnnotations;

namespace CoffeeSubscriptionManager.Models.Requests
{
    public class CustomerDto : BaseRequest
    {

        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string FirstLineOfAddress { get; set; }
        public string? SecondLineOfAddress { get; set; }
        public required string City { get; set; }
        public required string Postcode { get; set; }
        public List<Subscription>? Subscriptions { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
