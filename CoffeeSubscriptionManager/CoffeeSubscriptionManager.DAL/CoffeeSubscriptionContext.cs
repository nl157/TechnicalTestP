using CoffeeSubscriptionManager.DAL.Interfaces;
using CoffeeSubscriptionManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeSubscriptionManager.DAL
{
    public class CoffeeSubscriptionContext : DbContext, ICoffeeSubscriptionContext
    {
        public DbSet<Coffee> Coffee { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Subscription> Subscription { get; set; }

        public string DbPath { get; }

        public CoffeeSubscriptionContext() => DbPath = Path.Join((string?)Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffeeSubscription.db");

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        public int Save()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
