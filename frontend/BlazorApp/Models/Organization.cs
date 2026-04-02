using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PresidentId { get; set; }

        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public string StreetNumber { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string? Country { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public List<int> DojoIds { get; set; } = new();

        public Organization()
        {
            Name = string.Empty;
            PresidentId = 0;
            Street = string.Empty;
            StreetNumber = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            DojoIds = new List<int>();
        }

        public Organization(string name, int presidentId, string street, string streetNumber, string city, string? country, string email, string phoneNumber)
        {
            Name = name;
            PresidentId = presidentId;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}