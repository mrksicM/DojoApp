using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class OrganizationDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int PresidentId { get; set; }

        // Address
        public string Street { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string? Country { get; set; }

        // Contact
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public List<DojoDTO> Dojos { get; set; } = new();

        public OrganizationDTO() { }

        public OrganizationDTO(int id, string name, int presidentId, string street, string streetNumber, string city, string? country, string email, string phoneNumber, List<DojoDTO> dojos)
        {
            Id = id;
            Name = name;
            PresidentId = presidentId;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            Email = email;
            PhoneNumber = phoneNumber;
            Dojos = dojos;
        }
    }
}