using Domain.Entities;
using Application.DTOs;
using Domain.Interfaces;
using Application.Commands.Dojo;
using Domain.ValueObjects;

namespace Application.Handlers.Dojo
{
    public class CreateDojoHandler
    {
        private readonly IDojoRepository _repo;

        public CreateDojoHandler(IDojoRepository repo)
        {
            _repo = repo;
        }

        public async Task<DojoDTO> Handle(CreateDojoCommand cmd)
        {
            var dto = cmd.DojoDTO;

            // Map DTO -> Domain Entity
            var dojo = new Domain.Entities.Dojo()
            {
                Name = dto.Name,
                Contact = dto.Contact,
                Address = dto.Address,
                DojoChoId = dto.DojoChoId,
                Members = dto.Members.Select(m => new Member
                {
                    Name = new Name(m.FirstName, m.LastName),
                    PersonalInfo = new PersonalInfo
                    {
                        Address = new Address
                        {
                            Street = m.Street,
                            StreetNumber = m.StreetNumber,
                            City = m.City,
                            Country = m.Country
                        },
                        Contact = new Contact
                        {
                            Email = m.Email,
                            PhoneNumber = m.PhoneNumber
                        },
                        DateOfBirth = m.DateOfBirth,
                        ParentName = m.ParentFirstName != null && m.ParentLastName != null
                            ? new Name(m.ParentFirstName, m.ParentLastName)
                            : null
                    },
                    TraineeInfo = new TraineeInfo
                    {
                        Rank = m.Rank,
                        Belt = m.Belt,
                        Role = m.Role,
                        DateOfJoining = m.DateOfJoining,
                        Notes = m.NoteContent != null
                            ? new List<Note> { new Note { Content = m.NoteContent, CreatedAt = DateTime.Now, CreatedByMemberId = m.NoteCreatedByMemberId } }
                            : null, // Handle missing notes
                        AikidoId = m.AikidoId
                    },
                    IsActive = m.IsActive
                }).ToList()
            };

            await _repo.AddAsync(dojo);

            // Map Domain Entity -> DTO
            return new DojoDTO
            {
                Name = dojo.Name,
                Contact = dojo.Contact,
                Address = dojo.Address,
                DojoChoId = dojo.DojoChoId,
                Members = dojo.Members.Select(m => new MembersDTO
                {
                    FirstName = m.Name.FirstName,
                    LastName = m.Name.LastName,
                    Street = m.PersonalInfo.Address.Street,
                    StreetNumber = m.PersonalInfo.Address.StreetNumber,
                    City = m.PersonalInfo.Address.City,
                    Country = m.PersonalInfo.Address.Country,
                    Email = m.PersonalInfo.Contact.Email,
                    PhoneNumber = m.PersonalInfo.Contact.PhoneNumber,
                    DateOfBirth = m.PersonalInfo.DateOfBirth,
                    ParentFirstName = m.PersonalInfo.ParentName?.FirstName,
                    ParentLastName = m.PersonalInfo.ParentName?.LastName,
                    Rank = m.TraineeInfo.Rank,
                    Belt = m.TraineeInfo.Belt,
                    Role = m.TraineeInfo.Role,
                    DateOfJoining = m.TraineeInfo.DateOfJoining,
                    NoteContent = m.TraineeInfo.Notes != null
                        ? string.Join("; ", m.TraineeInfo.Notes.Select(n => n.Content)) : string.Empty,
                    AikidoId = m.TraineeInfo.AikidoId,
                    IsActive = m.IsActive
                }).ToList()
            };
        }
    }
}