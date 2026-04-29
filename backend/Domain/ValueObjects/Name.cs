using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name() { FirstName = ""; LastName = ""; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Name(Name name)
        {
            FirstName = name.FirstName;
            LastName = name.LastName;
        }
    }
}