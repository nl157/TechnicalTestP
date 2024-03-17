using CoffeeSubscriptionManager.Models;

namespace CoffeeSubscriptionManager.Services.Validators
{
    public class CustomerValidator : ICustomerValidator
    {
        public ServiceResult<bool> IsValidCustomer(Customer customer)
        {
            try
            {
                var validator = new NullOrEmptyValidator();
                validator.SetNext(new EmailValidator());
                validator.Validate(customer);
            }
            catch (Exception e)
            {
                return new ServiceResult<bool>(e);
            }

            return new ServiceResult<bool>(true);
        }
    }
}
