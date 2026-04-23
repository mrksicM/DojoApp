using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Dojo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Address
        public string Street { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string? Country { get; set; }

        // Contact
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        [Required]
        public int DojoChoId { get; set; }
        public List<Member> Members { get; set; } = new();

        public Dojo()
        {
            Name = string.Empty;
            Street = string.Empty;
            StreetNumber = string.Empty;
            City = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Country = string.Empty;
            Members = new List<Member>();
            DojoChoId = 0;
        }

        public Dojo(int id, string name, string street, string streetNumber, string city, string? country, string email, string phoneNumber, int dojoChoId)
        {
            Id = id;
            Name = name;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            Email = email;
            PhoneNumber = phoneNumber;
            DojoChoId = dojoChoId;
            Members = new List<Member>();
        }
    }
}