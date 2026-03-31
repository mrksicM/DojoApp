using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Address
    {
        public required string Street { get; set; }
        public required string StreetNumber { get; set; }
        public required string City { get; set; }
        public string? Country { get; set; }

        public Address() { }

        public Address(string street, string streetNumber, string city, string? country = null)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
        }
    }
}