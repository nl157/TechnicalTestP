using CoffeeSubscriptionManager.Models;

namespace CoffeeSubscriptionManager.Services
{
    /// <summary>
    /// Manages the chaining of Validations relating to the customer
    /// </summary>
    public interface ICustomerValidator
    {
        /// <summary>
        /// Check that all field in Customer is valid according to multiple criteria stored in Validators
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ServiceResult<bool> IsValidCustomer(Customer customer);
    }
}