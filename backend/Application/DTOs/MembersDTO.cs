using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class MembersDTO
    {
        public int Id { get; set; }

        // Name
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        // Address
        public string Street { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string City { get; set; } = "";
        public string? Country { get; set; }

        // Contact
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        // Personal info
        public required DateOnly DateOfBirth { get; set; }

        public string? ParentFirstName { get; set; } // Optional, only for children
        public string? ParentLastName { get; set; } // Optional, only for children

        // Trainee info
        public int Rank { get; set; }
        public string Belt { get; set; } = "";
        public string Role { get; set; } = "";
        public DateTime DateOfJoining { get; set; }
        public int DojoId { get; set; }
        public string AikidoId { get; set; } = "";
        public string? NoteContent { get; set; }
        public DateTime? NoteCreatedAt { get; set; }
        public int? NoteCreatedByMemberId { get; set; }
        //public List<NoteDTO> Notes { get; set; } = new();
        //public int NoteId { get; set; }
        // Status
        public bool IsActive { get; set; }

        public MembersDTO() { }
    }
}
