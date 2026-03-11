using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Contact
    {     
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

        public Contact() { }

        public Contact(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
        
    }
}