using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NRDCL_API.DTOs.Cus
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = "Citizenship ID is mendatory.")]
        [Display(Name = "Citizenship ID")]
        public string CitizenshipID { get; set; }

        [Required(ErrorMessage = "Customer name is mendatory.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Telephone number is mendatory.")]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Email ID")]
        public string EmailId { get; set; }
    }
}