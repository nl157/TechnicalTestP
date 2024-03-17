using CoffeeSubscriptionManager.Models;

namespace CoffeeSubscriptionManager.FrontEnd.Models
{
    public class CustomerViewModel
    {

        public IEnumerable<Customer>? Customers { get; set; }
        public Customer? Customer { get; set; }
    }
}
