using Bogus;
using CoffeeSubscriptionManager.Models;
namespace CoffeeSubscriptionManager.DAL
{
    public class DatabaseSeeder
    {

        public static void Seed(CoffeeSubscriptionContext context)
        {

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var coffees = GenerateCoffee();

            (Customer GeneratedCustomer, Subscription GeneratedSub, Order GeneratedOrder)[] generatedCustomerSubOrders = GenerateCustomerSubOrder(3, coffees);

            foreach (var custSubOrder in generatedCustomerSubOrders)
            {

                context.Customer.AddRange(custSubOrder.GeneratedCustomer);
                context.Subscription.AddRange(custSubOrder.GeneratedSub);
                context.Order.AddRange(custSubOrder.GeneratedOrder);
            }

            context.Coffee.AddRange(coffees);
            context.SaveChanges();
        }

        private static (Customer, Subscription, Order)[] GenerateCustomerSubOrder(int size, Coffee[] coffees)
        {
            var custSubOrder = new List<(Customer, Subscription, Order)>();
            for (int i = 0; i < size; i++)
            {

                var customer = new Faker<Customer>().RuleFor(c => c.Email, f => f.Person.Email)
                                                    .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                                                    .RuleFor(c => c.Surname, f => f.Person.LastName)
                                                    .RuleFor(c => c.City, f => f.Person.Address.City)
                                                    .RuleFor(c => c.Postcode, f => f.Address.ZipCode("???? ###"))
                                                    .RuleFor(c => c.FirstLineOfAddress, f => f.Address.StreetAddress())
                                                    .RuleFor(c => c.SecondLineOfAddress, f => f.Address.SecondaryAddress());

                var subscription = new Faker<Subscription>().RuleFor(c => c.Customer, f => customer)
                                                            .RuleFor(c => c.FrequencyInDays, f => f.Random.Int(0, 364))
                                                            .RuleFor(c => c.OrderSize, f => f.Random.Int(250, 1000).ToString())
                                                            .RuleFor(c => c.NextSendDate, f => f.Date.Future())
                                                            .RuleFor(c => c.BaseOrderPrice, f => f.Random.Int(0, 300))
                                                            .RuleFor(c => c.Coffee, f => f.PickRandom(coffees))
                                                            .RuleFor(c => c.PaymentMethod, f => f.Finance.TransactionType());


                var order = new Faker<Order>().RuleFor(c => c.Subscription, f => subscription);

                custSubOrder.Add((customer, subscription, order));
            }
            return [.. custSubOrder];
        }

        private static Coffee[] GenerateCoffee()
        {
            var faker = new Faker<Coffee>().RuleFor(c => c.Name, f => $"Coffee Number {f.Random.Int(1, 44)}")
                                           .RuleFor(c => c.Description, f => f.Commerce.ProductDescription());
            return [.. faker.GenerateBetween(3, 10)];
        }
    }
}
