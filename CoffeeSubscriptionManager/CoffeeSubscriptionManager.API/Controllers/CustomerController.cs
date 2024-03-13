using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeSubscriptionManager.API.Controllers
{
    /// <summary>
    /// Manages the CRUD actions for Customers
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Gets a list of all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCustomers), Name = nameof(GetAllCustomers))]
        [ProducesResponseType(typeof(IList<Customer>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomersAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error!.Message);
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Gets customer from the unique Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetCustomerFromId), Name = nameof(GetCustomerFromId))]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCustomerFromId(int id)
        {
            var result = await _customerService.GetCustomersByIdAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error!.Message);
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Creates a customer and inserts into database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut(nameof(CreateCustomer), Name = nameof(CreateCustomer))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var result = await _customerService.CreateCustomerAsync(customer);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error!.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(UpdateCustomer), Name = nameof(UpdateCustomer))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error!.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost(nameof(DeleteCustomer), Name = nameof(DeleteCustomer))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCustomer(int customerId)
        {
            var result = _customerService.DeleteCustomer(customerId);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error!.Message);
            }

            return NoContent();
        }
    }
}
