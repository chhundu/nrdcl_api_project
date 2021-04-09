using System;
using Xunit;
using NRDCL_API.Contollers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using NRDCL_API.Models.Cus;
using NRDCL_API.Data.Cus;
using NRDCL_API.Profiles.cus;
using NRDCL_API.DTOs.Cus;

namespace NRDCL_API.Tests
{
    public class HomeControllerTests : IDisposable
    {
        //Random change sadsad

        Mock<ICustomerService> mockCustomerService;
        CustomerProfile customerProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public HomeControllerTests()
        {
            mockCustomerService = new Mock<ICustomerService>();
            customerProfile = new CustomerProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(customerProfile));
            mapper = new Mapper(configuration);
        }
        public void Dispose()
        {
            mockCustomerService = null;
            mapper = null;
            configuration = null;
            customerProfile = null;
        }

        #region customer list test case
        /// <summary>
        /// Test ID: Test 1.1
        /// Arrange and action: Request Resources when 0 exist
        /// Assert: Return 200 OK HTTP Response
        /// </summary>
        [Fact]
        public void GetCustomerList_Retruns200OK_WhenDBIsEmpty()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerList()).Returns(GetCustomerDetail("0"));

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var customerList = homeController.GetCustomerList();

            //Assert
            Assert.IsType<OkObjectResult>(customerList.Result);
        }

        /// <summary>
        /// Test ID: Test 1.2
        /// Arrange and action: Request Resource when 1 exists
        /// Assert: Return Single Resource
        /// </summary>
        [Fact]
        public void GetCustomerList_RetrunsOneCustomer_WhenDBHasOneResource()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerList()).Returns(GetCustomerDetail("1"));

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var customerList = homeController.GetCustomerList();

            //Assert
            var OkResult = customerList.Result as OkObjectResult;
            var customers = OkResult.Value as List<CustomerDTO>;
            Assert.Single(customers);
        }

        /// <summary>
        /// Test ID: Test 1.3
        /// Arrange and action: Request Resource when 1 exists
        /// Assert: Return HTTP 200 OK
        /// </summary>
        [Fact]
        public void GetCustomerList_Retruns200OK_WhenDBHasOneResource()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerList()).Returns(GetCustomerDetail("1"));

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var result = homeController.GetCustomerList();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        /// <summary>
        /// Test ID: Test 1.4
        /// Arrange and action: Request Resource when 1 exists
        /// Assert: Return the correct "type"
        /// </summary>
        [Fact]
        public void GetCustomerList_RetrunsCorrectType_WhenDBHasOneResource()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerList()).Returns(GetCustomerDetail("1"));

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var result = homeController.GetCustomerList();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<CustomerDTO>>>(result);
        }
        #endregion customer list test case

        #region customer detail test case
        /// <summary>
        /// Test ID: Test 2.1
        /// Condition: Resource ID is invalid (does not exist in DB)
        /// Expected Result: 404 Not Found HTTP Response
        /// </summary>
        [Fact]
        public void GetCustomerDetail_Retruns404NotFound_WhenNonExistentIDProvided()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerDetails("0")).Returns(() => null);

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var result = homeController.GetCustomerDetail("1");

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /// <summary>
        /// Test ID: Test 2.2
        /// Condition: Resource ID is invalid (exists in DB)
        /// Expected Result: 200 Ok HTTP Response
        /// </summary>
        [Fact]
        public void GetCustomerDetail_Retruns200OK_WhenValidIDProvided()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerDetails("1")).Returns(new Customer
            {
                CitizenshipID = "1",
                CustomerName = "Chhundu",
                TelephoneNumber = "123",
                EmailId = "c@gmail.com"
            });

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var result = homeController.GetCustomerDetail("1");

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        /// <summary>
        /// Test ID: Test 2.3
        /// Condition: Resource ID is invalid (exists in DB)
        /// Expected Result: Correct Resource Type Returned
        /// </summary>
        [Fact]
        public void GetCustomerDetail_RetrunsCorrectResourceType_WhenValidIDProvided()
        {
            //arrange
            mockCustomerService.Setup(repo => repo.GetCustomerDetails("1")).Returns(new Customer
            {
                CitizenshipID = "1",
                CustomerName = "Chhundu",
                TelephoneNumber = "123",
                EmailId = "c@gmail.com"
            });

            //Instance of Home controller class
            var homeController = new HomeController(mockCustomerService.Object, mapper);

            //Act
            var result = homeController.GetCustomerDetail("1");

            //Assert
            Assert.IsType<ActionResult<CustomerDTO>>(result);
        }

        #endregion

        private List<Customer> GetCustomerDetail(string citizenshipID)
        {
            var customer = new List<Customer>();
            if (!citizenshipID.Equals("") || !citizenshipID.Equals(null))
            {
                customer.Add(new Customer
                {
                    CitizenshipID = "0",
                    CustomerName = "CHundu",
                    TelephoneNumber = "123",
                    EmailId = "c@gmail.com"
                });
            }
            return customer;
        }
    }
}