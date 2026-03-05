using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Name
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}