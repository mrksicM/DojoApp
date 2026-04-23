using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class DojoDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = "";

        // Address
        public string Street { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string? Country { get; set; }

        // Contact
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        public required int DojoChoId { get; set; }
        public string DojoChoName { get; set; } = "";
        public List<MembersDTO> Members { get; set; } = new();

        public DojoDTO()
        {

        }

        public DojoDTO(int id, string name, String street, string streetNumber, string city, string? country, string email, string phoneNumber, int dojoChoId, string dojoChoName, List<MembersDTO> members)
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
            DojoChoName = dojoChoName;
            Members = members;
        }

        public DojoDTO(int id, string name, Contact contact, Address address, int dojoChoId, string dojoChoName, List<MembersDTO> members)
        {
            Id = id;
            Name = name;
            Street = address.Street;
            StreetNumber = address.StreetNumber;
            City = address.City;
            Country = address.Country;
            Email = contact.Email;
            PhoneNumber = contact.PhoneNumber;
            DojoChoId = dojoChoId;
            DojoChoName = dojoChoName;
            Members = members;
        }
    }
}