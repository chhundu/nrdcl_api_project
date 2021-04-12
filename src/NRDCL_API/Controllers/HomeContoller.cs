using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NRDCL_API.Data.Cus;
using NRDCL_API.DTOs.Cus;
using NRDCL_API.Models.Cus;

namespace NRDCL_API.Contollers
{
    //Change
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;
        public HomeController(ICustomerService service, IMapper map)
        {
            customerService = service;
            mapper = map;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomerList()
        {
            var customerList = customerService.GetCustomerList();
            return Ok(mapper.Map<IEnumerable<CustomerDTO>>(customerList));
        }

        [HttpGet("{CitizenshipID}", Name = "GetCustomerDetail")]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomerDetail(string CitizenshipID)
        {
            var customer = customerService.GetCustomerDetails(CitizenshipID);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost]
        public ActionResult<CustomerDTO> SaveCustomer(CreateCustomerDTO createCustomerDTO)
        {
            var customer = mapper.Map<Customer>(createCustomerDTO);
            customerService.SaveCustomer(customer);
            customerService.SaveChanges();

            var customerDTO = mapper.Map<CustomerDTO>(customer);

            return CreatedAtRoute(nameof(GetCustomerDetail), new { CitizenshipID = customerDTO.CitizenshipID }, customerDTO);
        }

        [HttpPut("{citizenshipID}")]
        public ActionResult UpdateCustomer(string citizenshipID, UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = customerService.GetCustomerDetails(citizenshipID);
            if (customer == null)
            {
                return NotFound();
            }
            mapper.Map(updateCustomerDTO, customer);

            customerService.UpdateCustomer(customer);
            customerService.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{citizenshipID}")]
        public ActionResult DeleteCustomer(string citizenshipID)
        {
            var customer = customerService.GetCustomerDetails(citizenshipID);
            if (customer == null)
            {
                return NotFound();
            }
            customerService.DeleteCustomer(customer);
            customerService.SaveChanges();
            return NoContent();
        }
    }
}