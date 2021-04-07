using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NRDCL.Models.Cus;
using NRDCL_API.Data;

namespace NRDCL_API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public HomeController(ICustomerService service)
        {
            customerService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomerList()
        {
            var customerList = customerService.GetCustomerList();
            return Ok(customerList);
        }

        [HttpGet("{CitizenshipID}")]
        public ActionResult<IEnumerable<Customer>> GetCustomerDetail(string CitizenshipID)
        {
            var customer = customerService.GetCustomerDetails(CitizenshipID);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}