using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL_API.DTOs.Common;
using NRDCL_API.Models.Cus;

namespace NRDCL_API.Data.Cus
{
    public interface ICustomerService
    {
        bool SaveChanges();
        IEnumerable<Customer> GetCustomerList();
        Customer GetCustomerDetails(string CitizenshipID);
        Task<bool> IsCustomerExist(string citizenshipID);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
