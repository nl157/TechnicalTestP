using CoffeeSubscriptionManager.Models;
using CoffeeSubscriptionManager.Services.Validators;

namespace CoffeeSubscriptionManager.Tests
{
    [TestClass]
    public class CustomerValidatorTests
    {

        [TestMethod]
        public void Validate_ReturnsSuccessful()
        {
            var customer = CustomerHelper.CreateCustomer();

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Data);
        }


        [TestMethod]
        public void Validate_NullOrEmptyMultiple_ReturnsRelatedError()
        {
            var expectedMessage = "The following fields were null or empty : FirstName\r\nPostcode";
            var customer = CustomerHelper.CreateCustomer(firstName: null, postcode: "");

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [DataRow("")]
        [DataRow(null)]
        [TestMethod]
        public void Validate_NullOrEmptyFirstName_ReturnsRelatedError(string? input)
        {
            var expectedMessage = "The following fields were null or empty : FirstName";
            var customer = CustomerHelper.CreateCustomer(firstName: input);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [DataRow("")]
        [DataRow(null)]
        [TestMethod]
        public void Validate_NullOrEmptySurname_ReturnsRelatedError(string? input)
        {
            var expectedMessage = "The following fields were null or empty : Surname";
            var customer = CustomerHelper.CreateCustomer(surname: input);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [DataRow("")]
        [DataRow(null)]
        [TestMethod]
        public void Validate_NullOrEmptyEmail_ReturnsRelatedError(string? input)
        {
            var expectedMessage = "The following fields were null or empty : Email";
            var customer = CustomerHelper.CreateCustomer(email: input);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [DataRow("")]
        [DataRow(null)]
        [TestMethod]
        public void Validate_NullOrEmptyFirstLineOfAddress_ReturnsRelatedError(string? input)
        {
            var expectedMessage = "The following fields were null or empty : FirstLineOfAddress";
            var customer = CustomerHelper.CreateCustomer(firstLine: input);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [DataRow("")]
        [DataRow(null)]
        [TestMethod]
        public void Validate_NullOrEmptyCity_ReturnsRelatedError(string? input)
        {
            var expectedMessage = "The following fields were null or empty : City";
            var customer = CustomerHelper.CreateCustomer(city: input);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [DataRow("")]
        [DataRow(null)]
        [TestMethod]
        public void Validate_NullOrEmptyPostcode_ReturnsRelatedError(string? input)
        {
            var expectedMessage = "The following fields were null or empty : Postcode";
            var customer = CustomerHelper.CreateCustomer(postcode: input);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [TestMethod]
        public void Validate_InvalidEmail_ReturnsRelatedError()
        {
            var expectedMessage = "Email Address Invalid";
            var invalidEmail = "n,w,w,..a,.w.";
            var customer = CustomerHelper.CreateCustomer(email: invalidEmail);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedMessage, result.Error!.Message);
        }

        [TestMethod]
        public void Validate_ValidEmail_ReturnsSuccess()
        {
            var invalidEmail = "test@gmail.com";
            var customer = CustomerHelper.CreateCustomer(email: invalidEmail);

            var validator = new CustomerValidator();
            var result = validator.IsValidCustomer(customer);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Data);
        }
    }
}