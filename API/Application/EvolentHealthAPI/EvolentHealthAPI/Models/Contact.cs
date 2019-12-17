using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentHealthAPI.Models
{
    public class Contact
    {

        public string ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public bool Status { get; set; }

    }
}