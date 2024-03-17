using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Repository.Interfaces;
using CoffeeSubscriptionManager.Services.Interfaces;

namespace CoffeeSubscriptionManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly ICustomerValidator _customerValidator;

        public CustomerService(IGenericRepository<Customer> customerRepository, ICustomerValidator customerValidator)
        {
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
        }

        public async Task<ServiceResult<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            var result = await _customerRepository.GetAllAsync();

            if (result == null || result.Count == 0)
            {
                return new ServiceResult<IEnumerable<Customer>>(new Exception("Customer Response is null or empty"));
            }

            return new ServiceResult<IEnumerable<Customer>>(result);
        }

        public async Task<ServiceResult<Customer>> GetCustomersByIdAsync(int customerId)
        {
            var result = await _customerRepository.GetByIdAsync(customerId);

            if (result == null)
            {
                return new ServiceResult<Customer>(new Exception("Customer Response is null"));
            }

            return new ServiceResult<Customer>(result);
        }

        public async Task<ServiceResult<IEnumerable<Customer>>> CreateCustomerAsync(Customer customer)
        {
            var validationResult = _customerValidator.IsValidCustomer(customer);

            if (!validationResult.IsSuccess && !validationResult.Data)
            {
                return new ServiceResult<IEnumerable<Customer>>(new Exception(validationResult.Error!.Message));
            }

            try
            {
                await _customerRepository.AddAsync(customer);
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<Customer>>(e);
            }


            return new ServiceResult<IEnumerable<Customer>>();
        }

        public ServiceResult<bool> DeleteCustomer(int customerId)
        {
            var isCustomerRemoved = _customerRepository.Remove(customerId);

            if (isCustomerRemoved)
            {
                return new ServiceResult<bool>(isCustomerRemoved);
            }

            return new ServiceResult<bool>(new Exception("Unable to Delete Customer"));
        }

        public ServiceResult<IEnumerable<Customer>> UpdateCustomer(Customer customer)
        {
            var validationResult = _customerValidator.IsValidCustomer(customer);

            if (!validationResult.IsSuccess && !validationResult.Data)
            {
                return new ServiceResult<IEnumerable<Customer>>(new Exception(validationResult.Error!.Message));
            }

            try
            {
                _customerRepository.Update(customer);
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<Customer>>(e);
            }

            return new ServiceResult<IEnumerable<Customer>>();
        }
    }
}
