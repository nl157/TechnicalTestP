using CoffeeSubscriptionManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeSubscriptionManager.DAL.Interfaces
{
    public interface ICoffeeSubscriptionContext
    {
        DbSet<Coffee> Coffee { get; set; }
        DbSet<Customer> Customer { get; set; }
        string DbPath { get; }
        DbSet<Subscription> Subscription { get; set; }

        int Save();

        Task<int> SaveAsync();
    }
}