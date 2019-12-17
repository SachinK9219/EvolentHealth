using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvolentHealthUI.Models
{
    public class Contact
    {

        public string ID { get; set; }


        [Display(Name = " First Name")]
        [Required(ErrorMessage = "You must provide a First Name")]
        public string FirstName { get; set; }

        [Display(Name = " Last Name")]
        [Required(ErrorMessage = "You must provide a Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a Email Address")]
        [Display(Name = " Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }


        public bool Status { get; set; }

    }
}