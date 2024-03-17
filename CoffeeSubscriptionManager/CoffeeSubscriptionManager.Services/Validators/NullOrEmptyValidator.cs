
using CoffeeSubscriptionManager.Models;

namespace CoffeeSubscriptionManager.Services
{
    public class NullOrEmptyValidator : Validator<Customer>
    {
        public override void Validate(Customer customer)
        {
            var errors = new List<string>();

            if (customer.FirstName == null || customer.FirstName == "")
            {
                errors.Add(nameof(customer.FirstName));
            }

            if (customer.Surname == null || customer.Surname == "")
            {
                errors.Add(nameof(customer.Surname));
            }

            if (customer.Email == null || customer.Email == "")
            {
                errors.Add(nameof(customer.Email));
            }

            if (customer.FirstLineOfAddress == null || customer.FirstLineOfAddress == "")
            {
                errors.Add(nameof(customer.FirstLineOfAddress));
            }

            if (customer.City == null || customer.City == "")
            {
                errors.Add(nameof(customer.City));
            }

            if (customer.Postcode == null || customer.Postcode == "")
            {
                errors.Add(nameof(customer.Postcode));
            }

            if (errors.Count != 0)
            {
                throw new Exception($"The following fields were null or empty : {string.Join(Environment.NewLine, errors)}");
            }

            base.Validate(customer);
        }
    }
}