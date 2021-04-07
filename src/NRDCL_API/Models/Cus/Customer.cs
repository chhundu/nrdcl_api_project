using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NRDCL.Models.Cus
{
    public class Customer
    {
        [Key]
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

        [NotMapped]
        public string CMDstatus { get; set; }
    }
}