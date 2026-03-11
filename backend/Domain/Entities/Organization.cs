using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int PresidentId { get; set; }
        public required Contact Contact { get; set; }
        public required Address Address { get; set; }
        public List<Dojo> Dojos { get; set; } = new ();

        public Organization(int id, string name, int presidentId, Contact contact, Address address)
        {
            Id = id;
            Name = name;
            PresidentId = presidentId;
            Contact = contact;
            Address = address;
        }
    }
}