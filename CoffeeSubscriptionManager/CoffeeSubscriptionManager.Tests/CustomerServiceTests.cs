using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Repository;
using CoffeeSubscriptionManager.Repository.Interfaces;
using CoffeeSubscriptionManager.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSubscriptionManager.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private List<Customer> CreateCustomers(params Customer[] customer)
        {
            return customer.ToList();
        }

        [TestMethod]
        public async Task GetAllCustomersAsync_ReturnsSuccessful()
        {
            var expectedName = "Joe";
            var expectedOtherName = "Sarah";

            var repository = new Mock<IGenericRepository<Customer>>();
            repository.Setup(x => x.GetAllAsync()).ReturnsAsync(CreateCustomers(CustomerHelper.CreateCustomer(firstName: expectedName), CustomerHelper.CreateCustomer(firstName: expectedOtherName)));
            var validator = new Mock<ICustomerValidator>();
            var service = new CustomerService(repository.Object, validator.Object);

            var result = await service.GetAllCustomersAsync();

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(expectedName, result.Data.First().FirstName);
            Assert.AreEqual(expectedOtherName, result.Data.Last().FirstName);
        }

        [TestMethod]
        public async Task GetAllCustomersAsync_EmptyResponse_ReturnsError()
        {
            var expectedError = "Customer Response is null or empty";
            var repository = new Mock<IGenericRepository<Customer>>();
            repository.Setup(x => x.GetAllAsync()).ReturnsAsync(CreateCustomers());
            var validator = new Mock<ICustomerValidator>();
            var service = new CustomerService(repository.Object, validator.Object);

            var result = await service.GetAllCustomersAsync();

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedError, result.Error!.Message);
        }

        [TestMethod]
        public async Task GetCustomersByIdAsync_ReturnsSuccessful()
        {
            var expectedId = 2;
            var repository = new Mock<IGenericRepository<Customer>>();
            repository.Setup(x => x.GetByIdAsync(expectedId)).ReturnsAsync( CustomerHelper.CreateCustomer(id: expectedId));
            var validator = new Mock<ICustomerValidator>();
            var service = new CustomerService(repository.Object, validator.Object);

            var result = await service.GetCustomersByIdAsync(expectedId);

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(expectedId, result.Data.Id);
        }

        [TestMethod]
        public async Task GetCustomersByIdAsync_ReturnsError()
        {
            var expectedError = "Customer Response is null";
            var repository = new Mock<IGenericRepository<Customer>>();
            repository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var validator = new Mock<ICustomerValidator>();
            var service = new CustomerService(repository.Object, validator.Object);

            var result = await service.GetCustomersByIdAsync(2);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedError, result.Error!.Message);
        }

        //Tests for rest of class
    }
}
