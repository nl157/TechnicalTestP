using CoffeeSubscriptionManager.Models;

namespace CoffeeSubscriptionManager.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ServiceResult<IEnumerable<Customer>>> CreateCustomerAsync(Customer customer);
        ServiceResult<bool> DeleteCustomer(int customerId);
        Task<ServiceResult<IEnumerable<Customer>>> GetAllCustomersAsync();
        Task<ServiceResult<Customer>> GetCustomersByIdAsync(int customerId);
        ServiceResult<IEnumerable<Customer>> UpdateCustomer(Customer customer);
    }
}