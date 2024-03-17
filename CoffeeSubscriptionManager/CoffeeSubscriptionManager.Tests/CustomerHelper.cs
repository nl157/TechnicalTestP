using CoffeeSubscriptionManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSubscriptionManager.Tests
{
    public static class CustomerHelper
    {
        public static Customer CreateCustomer(string? firstName = "Peter", string? surname = "Parker", string? email = "PeterParker@gmail.com", string? firstLine = "FirstLine", string? city = "City", string? postcode = "SA2 1EE", int id = 0)
        {
            if (id == 0)
            {
                var random = new Random();
                id = random.Next(0, 1000);
            }

            return new Customer()
            {
                Id = id,
                FirstName = firstName!,
                Surname = surname!,
                Email = email!,
                FirstLineOfAddress = firstLine!,
                City = city!,
                Postcode = postcode!
            };
        }

    }
}
