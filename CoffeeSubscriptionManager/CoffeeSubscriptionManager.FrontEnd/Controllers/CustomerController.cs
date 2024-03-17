using CoffeeSubscriptionManager.FrontEnd.Models;
using CoffeeSubscriptionManager.FrontEnd.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace CoffeeSubscriptionManager.FrontEnd.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IOptions<ApiOptions> _apiOptions;

        public CustomerController(ILogger<CustomerController> logger,
            IOptions<ApiOptions> apiOptions)
        {
            _logger = logger;
            _apiOptions = apiOptions;
        }


        [HttpGet]
        public async Task<IActionResult> Customer() => View(await UpdateCustomerViewModel());

        private async Task<CustomerViewModel> UpdateCustomerViewModel()
        {
            var client = new Client(_apiOptions.Value.BaseAddress, new HttpClient());

            var result = await client.GetAllCustomersAsync();

            var customerViewModel = new CustomerViewModel
            {
                Customers = result,
                Customer = null
            };
            return customerViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromForm] Customer CreatedCustomer)
        {
            var client = new Client(_apiOptions.Value.BaseAddress, new HttpClient());

            await client.CreateCustomerAsync(CreatedCustomer);
            var viewModel = await UpdateCustomerViewModel();

            return View("Customer", viewModel);
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomer(int customerId)
        {
            var client = new Client(_apiOptions.Value.BaseAddress, new HttpClient());

            var customer = await client.GetCustomerFromIdAsync(customerId);
            return View("UpdateCustomer", new UpdateViewModel() { Customer = customer });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer([FromForm] Customer customer)
        {
            var client = new Client(_apiOptions.Value.BaseAddress, new HttpClient());

            await client.UpdateCustomerAsync(customer);

            var customerViewModel = await UpdateCustomerViewModel();
            customerViewModel.Customer = new Customer();

            return View("Customer", customerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var client = new Client(_apiOptions.Value.BaseAddress, new HttpClient());

            await client.DeleteCustomerAsync(customerId);
            CustomerViewModel customerViewModel = await UpdateCustomerViewModel();
            return View("Customer", customerViewModel);
        }

        [HttpGet]
        public IActionResult CreateCustomerForm()
        {
            return View("CreateCustomer", new CreateViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
