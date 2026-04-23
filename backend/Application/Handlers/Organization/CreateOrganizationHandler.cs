using Application.Commands.Organization;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Handlers.Organization
{
    public class CreateOrganizationHandler
    {
        private readonly IOrganizationRepository _repo;

        public CreateOrganizationHandler(IOrganizationRepository repo)
        {
            _repo = repo;
        }

        public async Task<OrganizationDTO> Handle(CreateOrganizationCommand cmd)
        {
            var dto = cmd.OrganizationDTO;
            var organization = new Domain.Entities.Organization()
            {
                Id = dto.Id,
                Name = dto.Name,
                PresidentId = dto.PresidentId,
                Address = new Address
                {
                    Street = dto.Street,
                    StreetNumber = dto.StreetNumber,
                    City = dto.City,
                    Country = dto.Country
                },
                Contact = new Contact
                {
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                },
                Dojos = dto.Dojos.Select(d => new Domain.Entities.Dojo
                {
                    Id = d.Id,
                    Name = d.Name,
                    Address = new Address
                    {
                        Street = d.Street,
                        StreetNumber = d.StreetNumber,
                        City = d.City,
                        Country = d.Country
                    },
                    Contact = new Contact
                    {
                        Email = d.Email,
                        PhoneNumber = d.PhoneNumber
                    },
                    DojoChoId = d.DojoChoId,
                    Members = d.Members.Select(m => new Member
                    {
                        Id = m.Id,
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
                                ? new Domain.ValueObjects.Name(m.ParentFirstName, m.ParentLastName)
                                : null
                        },
                        TraineeInfo = new TraineeInfo
                        {
                            Rank = m.Rank,
                            Belt = m.Belt,
                            Role = m.Role,
                            DateOfJoining = m.DateOfJoining,
                            AikidoId = m.AikidoId
                        },
                        IsActive = m.IsActive
                    }).ToList()
                }).ToList()
            };
            await _repo.AddAsync(organization);
            return new OrganizationDTO()
            {
                Id = organization.Id,
                Name = organization.Name,
                PresidentId = organization.PresidentId,
                Dojos = organization.Dojos.Select(d => new DojoDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Street = d.Address.Street,
                    StreetNumber = d.Address.StreetNumber,
                    City = d.Address.City,
                    Country = d.Address.Country,
                    Email = d.Contact.Email,
                    PhoneNumber = d.Contact.PhoneNumber,
                    DojoChoId = d.DojoChoId,
                    Members = d.Members.Select(m => new MembersDTO
                    {
                        Id = m.Id,
                        FirstName = m.Name.FirstName,
                        LastName = m.Name.LastName,
                        Street = m.PersonalInfo.Address.Street,
                        StreetNumber = m.PersonalInfo.Address.StreetNumber.ToString(),
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
                        AikidoId = m.TraineeInfo.AikidoId,
                        IsActive = m.IsActive
                    }).ToList()
                }).ToList()
            };
        }


    }
}