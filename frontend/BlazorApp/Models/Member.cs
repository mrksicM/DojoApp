using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Member
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public int StreetNumber { get; set; } = 0;

        [Required]
        public string City { get; set; } = string.Empty;

        public string? Country { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public string? ParentFirstName { get; set; } = string.Empty;

        [Required]
        public int Rank { get; set; } = 0;

        [Required]
        public string Belt { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public DateTime DateOfJoining { get; set; } = DateTime.Now;

        [Required]
        public string AikidoId { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        //Constructors
        public Member()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Street = string.Empty;
            StreetNumber = 0;
            City = string.Empty;
            Country = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            DateOfBirth = DateTime.Now;
            ParentFirstName = string.Empty;
            Rank = 0;
            Belt = string.Empty;
            Role = string.Empty;
            DateOfJoining = DateTime.Now;
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
        public Member(string firstName, string lastName, string street, int streetNumber, string city, string? country,
                      string email, string phoneNumber, DateTime dateOfBirth, string? parentFirstName,
                      int rank, string belt, string role, DateTime dateOfJoining, string aikidoId, bool isActive = true)
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
            Rank = rank;
            Belt = belt;
            Role = role;
            DateOfJoining = dateOfJoining;
            AikidoId = aikidoId;
            IsActive = isActive;
        }
    }
}