using System.Linq.Expressions;

namespace CoffeeSubscriptionManager.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        bool Remove(int id);
        void Update(T sender);
        int Save();
        Task<int> SaveAsync();
        T Select(Expression<Func<T, bool>> predicate);
        Task<T?> SelectAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T sender);
    }
}
