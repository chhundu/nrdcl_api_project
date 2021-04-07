using NRDCL.Models.Cus;
using NRDCL.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NRDCL_API.Data
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomerList();
        Customer GetCustomerDetails(string CitizenshipID);
        Task<bool> IsCustomerExist(string citizenshipID);
        Task<ResponseMessage> SaveCustomer(Customer customer);
        Task<ResponseMessage> UpdateCustomer(Customer customer);
        ResponseMessage DeleteCustomer(string citizenshipID);
    }
}
