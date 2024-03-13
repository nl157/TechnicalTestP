
using CoffeeSubscriptionManager.Models;

namespace CoffeeSubscriptionManager.Services
{
    public class NullValidator : Validator<Customer>
    {
        public override void Validate(Customer customer)
        {
            var errors = new List<string>();

            if (customer.FirstName == null)
            {
                errors.Add(nameof(customer.FirstName));
            }

            if (customer.Surname == null)
            {
                errors.Add(nameof(customer.Surname));
            }

            if (customer.Email == null)
            {
                errors.Add(nameof(customer.Email));
            }

            if (customer.FirstLineOfAddress == null)
            {
                errors.Add(nameof(customer.FirstLineOfAddress));
            }

            if (customer.City == null)
            {
                errors.Add(nameof(customer.City));
            }

            if (customer.Postcode == null)
            {
                errors.Add(nameof(customer.Postcode));
            }

            if (errors.Any())
            {
                throw new Exception($"The following field were null : {string.Join(Environment.NewLine, errors)}");
            }

            base.Validate(customer);
        }
    }
}