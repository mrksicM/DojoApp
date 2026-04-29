using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class AikidoEvent
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Type { get; set; } // Seminar, Grading, Embukai, etc.
        public required DateTime Date { get; set; }
        public required Address Address { get; set; }
        public required Contact Contact { get; set; }
        public string? Description { get; set; }
        public int? OrganizerId { get; set; }
        public Member? Organizer { get; set; }
        public int? PresenterId { get; set; }
        public Member? Presenter { get; set; }

        public AikidoEvent()
        {

        }

        public AikidoEvent(int id, string title, string type, DateTime date, Address address, Contact contact, string? description = null, int? organizerId = null, int? presenterId = null)
        {
            Id = id;
            Title = title;
            Type = type;
            Date = date;
            Address = address;
            Contact = contact;
            Description = description;
            OrganizerId = organizerId;
            PresenterId = presenterId;
        }
    }
}