using System;
using Xunit;
using NRDCL_API.Models.Cus;

namespace NRDCL_API.Tests
{
    public class CustomerTest : IDisposable
    {
        Customer testCustomer;
        public CustomerTest()
        {
            testCustomer = new Customer
            {
                CitizenshipID = "1",
                CustomerName = "Chhundu",
                EmailId = "c@gmail.com",
                TelephoneNumber = "123"
            };
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Arange 

            //Act
            testCustomer.CitizenshipID = "2";

            //Assert
            Assert.Equal("2", testCustomer.CitizenshipID);

        }

        public void Dispose()
        {
            testCustomer = null;
        }
    }
}