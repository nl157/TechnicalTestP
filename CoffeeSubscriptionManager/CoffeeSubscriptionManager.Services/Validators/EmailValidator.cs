
using CoffeeSubscriptionManager.Models;
using System.Text.RegularExpressions;

namespace CoffeeSubscriptionManager.Services
{
    public class EmailValidator : Validator<Customer>
    {
        public override void Validate(Customer customer)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(customer.Email);

            if (!match.Success)
            {
                throw new Exception("Email Adress Invalid");
            }

            base.Validate(customer);
        }
    }
}