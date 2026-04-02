using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public string StreetNumber { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public string? Country { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string? ParentFirstName { get; set; } = string.Empty;
        public string? ParentLastName { get; set; } = string.Empty;

        [Required]
        public int Rank { get; set; } = 0;

        [Required]
        public string Belt { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public DateTime DateOfJoining { get; set; } = DateTime.Now;

        [Required]
        public string AikidoId { get; set; } = string.Empty;

        //public Note? Notes { get; set; }

        // Flattened note fields
        public string? NoteContent { get; set; }
        public DateTime? NoteCreatedAt { get; set; }
        public int? NoteCreatedByMemberId { get; set; }

        public bool IsActive { get; set; } = true;

        //Constructors
        public Member()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Street = string.Empty;
            StreetNumber = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now);
            ParentFirstName = string.Empty;
            ParentLastName = string.Empty;
            Rank = 0;
            Belt = string.Empty;
            Role = string.Empty;
            DateOfJoining = DateTime.Now;
            NoteContent = string.Empty;
            NoteCreatedAt = null;
            NoteCreatedByMemberId = null;
            AikidoId = string.Empty;
            IsActive = true;
        }

        public Member(string firstName, string lastName, string email, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }
        public Member(string firstName, string lastName, string street, string streetNumber, string city,
                        string? country, string email, string phoneNumber, DateOnly dateOfBirth,
                        string? parentFirstName, string? parentLastName, int rank, string belt,
                        string role, DateTime dateOfJoining, Note? notes, string aikidoId, bool isActive = true)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Country = country;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            ParentFirstName = parentFirstName;
            ParentLastName = parentLastName;
            Rank = rank;
            Belt = belt;
            Role = role;
            DateOfJoining = dateOfJoining;
            NoteContent = notes?.Content;
            NoteCreatedAt = notes?.CreatedAt;
            NoteCreatedByMemberId = notes?.CreatedByMemberId;
            AikidoId = aikidoId;
            IsActive = isActive;
        }
    }
}