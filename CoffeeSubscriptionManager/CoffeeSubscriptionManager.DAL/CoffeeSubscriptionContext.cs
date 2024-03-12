using CoffeeSubscriptionManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeSubscriptionManager.DAL
{
    public class CoffeeSubscriptionContext : DbContext
    {
        public DbSet<Accessory> Accessories { get; set; }

        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<CoffeeBatch> CoffeeBatches { get; set; }

        public DbSet<ContactPreference> ContactPreferences { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<GrindSize> GrindSizes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public string DbPath { get; }

        public CoffeeSubscriptionContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "CoffeeSubscription.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
