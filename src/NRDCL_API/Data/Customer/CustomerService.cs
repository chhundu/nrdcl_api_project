using NRDCL.Models.Cus;
using NRDCL.Models.Common;
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

        public ResponseMessage DeleteCustomer(string CitizenshipID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            // var customer=GetCustomerDetails(CitizenshipID);
            // dataBaseContext.Customer_Table.Remove(customer.Result);
            // dataBaseContext.SaveChanges();
            // responseMessage.Status = true;
            // responseMessage.Text = CommonProperties.deleteSuccessMsg;
            return responseMessage;
        }

        public async Task<bool> IsCustomerExist(string citizenshipID)
        {
            return await Task.FromResult(true);
            // return await Task.FromResult(dataBaseContext.Customer_Table.Any(x => x.CitizenshipID.Equals(citizenshipID)));
        }

        public async Task<ResponseMessage> SaveCustomer(Customer customer)
        {

            ResponseMessage responseMessage = new ResponseMessage();

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

            return await Task.FromResult(responseMessage);
        }

        public async Task<ResponseMessage> UpdateCustomer(Customer customer)
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
            return await Task.FromResult(responseMessage);
        }
    }
}