using NRDCL_API.Data.Cus;
using NRDCL_API.DTOs.Common;
using NRDCL_API.Models.Cus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRDCL_API.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly NRDCL_API_DB_Context dataBaseContext;
        public CommonProperties CommonProperties { get; set; }

        public CustomerService(NRDCL_API_DB_Context context)
        {
            dataBaseContext = context;
        }

        /// <summary>
        /// This method is use to get customer detail based on CitizenshipID
        /// </summary>
        /// <param name="CitizenshipID"></param>
        /// <returns></returns>
        public Customer GetCustomerDetails(String CitizenshipID)
        {
            // var customer = (from cus in dataBaseContext.Customer_Table where cus.CitizenshipID.Equals(CitizenshipID) select cus).SingleOrDefault();
            // return await Task.FromResult(customer);
            return dataBaseContext.Customer_Table.FirstOrDefault(c => c.CitizenshipID.Equals(CitizenshipID));
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            // List<Customer> customerList = dataBaseContext.Customer_Table.ToList();
            // return await Task.Run(() => customerList) ;

            return dataBaseContext.Customer_Table.ToList();
        }

        public void DeleteCustomer(Customer customer)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            // var customer=GetCustomerDetails(CitizenshipID);
            // dataBaseContext.Customer_Table.Remove(customer.Result);
            // dataBaseContext.SaveChanges();
            // responseMessage.Status = true;
            // responseMessage.Text = CommonProperties.deleteSuccessMsg;
            //return responseMessage;

            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            dataBaseContext.Customer_Table.Remove(customer);
        }

        public async Task<bool> IsCustomerExist(string citizenshipID)
        {
            return await Task.FromResult(true);
            // return await Task.FromResult(dataBaseContext.Customer_Table.Any(x => x.CitizenshipID.Equals(citizenshipID)));
        }

        public void SaveCustomer(Customer customer)
        {

            // ResponseMessage responseMessage = new ResponseMessage();

            // if (IsCustomerExist(customer.CitizenshipID).Result)
            // {
            //     responseMessage.Status = false;
            //     responseMessage.Text = CommonProperties.citizenshipIDExistMsg;
            //     responseMessage.MessageKey = "CitizenshipID";
            //     return responseMessage;
            // }

            // dataBaseContext.Add(customer);
            // dataBaseContext.SaveChanges();
            // responseMessage.Status = true;
            // responseMessage.Text = CommonProperties.saveSuccessMsg;

            // return await Task.FromResult(responseMessage);

            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            // try
            // {
            //     dataBaseContext.Update(customer);
            //     await dataBaseContext.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!IsCustomerExist(customer.CitizenshipID).Result)
            //     {
            //         responseMessage.Status = false;
            //         responseMessage.Text = CommonProperties.citizenshipIDNotRegisteredMsg;
            //         responseMessage.MessageKey = "CitizenshipID";
            //         return responseMessage;
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }
            // responseMessage.Status = true;
            // responseMessage.Text = CommonProperties.updateSuccessMsg;
            //return await Task.FromResult(responseMessage);
        }

        public bool SaveChanges()
        {
            return (dataBaseContext.SaveChanges() >= 0);
        }
    }
}