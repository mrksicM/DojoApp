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
        public required string Name { get; set; }
        public required Contact Contact { get; set; }
        public required Address Address { get; set; }
        public required int DojoChoId { get; set; }
        public List<MembersDTO> Members { get; set; } = new();

        public DojoDTO()
        {
            
        }

        public DojoDTO(int id, string name, Contact contact, Address address, int dojoChoId)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Address = address;
            DojoChoId = dojoChoId;
        }
    }
}