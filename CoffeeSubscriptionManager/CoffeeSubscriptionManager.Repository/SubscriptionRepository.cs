using CoffeeSubscriptionManager.DAL.Interfaces;
using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Repository.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;

namespace CoffeeSubscriptionManager.Repository
{
    public class SubscriptionRepository : IGenericRepository<Subscription>
    {

        public Task AddAsync(Subscription sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscription> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscription>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Subscription? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Subscription Select(Expression<Func<Subscription, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription?> SelectAsync(Expression<Func<Subscription, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Subscription sender)
        {
            throw new NotImplementedException();
        }
    }
}