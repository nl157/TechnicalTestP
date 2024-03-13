using CoffeeSubscriptionManager.DAL.Interfaces;
using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Repository.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;

namespace CoffeeSubscriptionManager.Repository
{
    public class CoffeeRepository : IGenericRepository<Coffee>
    {

        public Task AddAsync(Coffee sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Coffee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Coffee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Coffee? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Coffee?> GetByIdAsync(int id)
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

        public Coffee Select(Expression<Func<Coffee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Coffee> SelectAsync(Expression<Func<Coffee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Coffee sender)
        {
            throw new NotImplementedException();
        }
    }
}