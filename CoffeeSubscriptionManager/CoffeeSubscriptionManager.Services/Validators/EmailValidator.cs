
using CoffeeSubscriptionManager.Models;
using System.Text.RegularExpressions;

namespace CoffeeSubscriptionManager.Services
{
    public partial class EmailValidator : Validator<Customer>
    {
        public override void Validate(Customer customer)
        {
            var regex = EmailRegex();
            var match = regex.Match(customer.Email);

            if (!match.Success)
            {
                throw new Exception("Email Address Invalid");
            }

            base.Validate(customer);
        }

        [GeneratedRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        private static partial Regex EmailRegex();
    }
}