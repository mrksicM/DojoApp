using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Address
    {
        public required string Street { get; set; }
        public required int StreetNumber { get; set; }
        public required string City { get; set; }
        public string? Country { get; set; }
    }
}