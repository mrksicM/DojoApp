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
        public required Contact Contact { get; set; }
        public required Address Address { get; set; }
        public List<DojoDTO> Dojos { get; set; } = new ();

        public OrganizationDTO() { }

        public OrganizationDTO(int id, string name, int presidentId, Contact contact, Address address, List<DojoDTO> dojos)
        {
            Id = id;
            Name = name;
            PresidentId = presidentId;
            Contact = contact;
            Address = address;
            Dojos = dojos;
        }
    }
}