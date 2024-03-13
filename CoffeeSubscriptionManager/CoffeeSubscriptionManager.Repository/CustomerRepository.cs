using CoffeeSubscriptionManager.DAL.Interfaces;
using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoffeeSubscriptionManager.Repository
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly ICoffeeSubscriptionContext _coffeeSubscriptionContext;

        public CustomerRepository(ICoffeeSubscriptionContext coffeeSubscriptionContext)
        {
            _coffeeSubscriptionContext = coffeeSubscriptionContext;
        }

        public async Task AddAsync(Customer sender)
        {
            await _coffeeSubscriptionContext.Customer.AddAsync(sender);
        }

        public IEnumerable<Customer> GetAll()
        {
            return [.. _coffeeSubscriptionContext.Customer];
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _coffeeSubscriptionContext.Customer.ToListAsync();
        }

        public Customer? GetById(int id)
        {
            return _coffeeSubscriptionContext.Customer.Find(id);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _coffeeSubscriptionContext.Customer.FindAsync(id);
        }


        public bool Remove(int id)
        {
            var customer = _coffeeSubscriptionContext.Customer.Find(id);

            if (customer is not null)
            {
                _coffeeSubscriptionContext.Customer.Remove(customer); 
                return true;
            }

            return false;
        }

        public int Save()
        {
            return _coffeeSubscriptionContext.Save();
        }

        public Task<int> SaveAsync()
        {
            return _coffeeSubscriptionContext.SaveAsync();
        }

        public Customer Select(Expression<Func<Customer, bool>> predicate)
        {
            return _coffeeSubscriptionContext.Customer.Where(predicate).FirstOrDefault()!;
        }

        public async Task<Customer?> SelectAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _coffeeSubscriptionContext.Customer.Where(predicate).FirstOrDefaultAsync()!;
        }

        public void Update(Customer sender)
        {
            _coffeeSubscriptionContext.Customer.Entry(sender).State = EntityState.Modified;
        }
    }
}