using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class AikidoEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } // Seminar, Grading, Embukai, etc.
        public DateTime Date { get; set; }

        // Address
        public string Street { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string? Country { get; set; }

        // Contact
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        public string? Description { get; set; }
        public int? OrganizerId { get; set; }
        public Member? Organizer { get; set; }
        public int? PresenterId { get; set; }
        public Member? Presenter { get; set; }
        public List<int> AttendeesIds { get; set; } = new();

        public AikidoEvent()
        {
            Title = string.Empty;
            Type = string.Empty;
            Street = string.Empty;
            StreetNumber = string.Empty;
            City = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Description = string.Empty;
            OrganizerId = null;
            PresenterId = null;
            Organizer = null;
            Presenter = null;
        }
        public AikidoEvent(int id, string title, string type, DateTime date, string street, string streetNumber, string city, string? country, string email, string phoneNumber, string? description, int? organizerId, int? presenterId, Member? organizer, Member? presenter)
        {
            Id = id;
            Title = title;
            Type = type;
            Date = date;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            Email = email;
            PhoneNumber = phoneNumber;
            Description = description;
            OrganizerId = organizerId;
            PresenterId = presenterId;
            Organizer = organizer;
            Presenter = presenter;
        }
    }
}