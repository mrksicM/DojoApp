using Application.Commands.Members;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Handlers.Members
{
    public class CreateMemberHandler
    {
        private readonly IMemberRepository _repo;

        public CreateMemberHandler(IMemberRepository repo)
        {
            _repo = repo;
        }

        public async Task<MembersDTO> Handle(CreateMemberCommand cmd)
        {
            var dto = cmd.MemberDTO;
            var member = new Member()
            {
                Name = new Name(dto.FirstName, dto.LastName),
                PersonalInfo = new PersonalInfo
                {
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
                    DateOfBirth = dto.DateOfBirth,
                    ParentName = dto.ParentFirstName != null && dto.ParentLastName != null
                        ? new Name(dto.ParentFirstName, dto.ParentLastName)
                        : null // Handle missing parent info
                },
                TraineeInfo = new TraineeInfo
                {
                    Rank = dto.Rank,
                    Belt = dto.Belt,
                    Role = dto.Role,
                    DateOfJoining = dto.DateOfJoining,
                    AikidoId = dto.AikidoId
                },
                IsActive = dto.IsActive
            };
            await _repo.AddAsync(member);
            return new MembersDTO()
            {
                Id = member.Id,
                FirstName = member.Name.FirstName,
                LastName = member.Name.LastName,
                Street = member.PersonalInfo.Address.Street,
                StreetNumber = member.PersonalInfo.Address.StreetNumber.ToString(),
                City = member.PersonalInfo.Address.City,
                Country = member.PersonalInfo.Address.Country,
                Email = member.PersonalInfo.Contact.Email,
                PhoneNumber = member.PersonalInfo.Contact.PhoneNumber,
                DateOfBirth = member.PersonalInfo.DateOfBirth,
                ParentFirstName = member.PersonalInfo.ParentName?.FirstName,
                ParentLastName = member.PersonalInfo.ParentName?.LastName,
                Rank = member.TraineeInfo.Rank,
                Belt = member.TraineeInfo.Belt,
                Role = member.TraineeInfo.Role,
                DateOfJoining = member.TraineeInfo.DateOfJoining,
                AikidoId = member.TraineeInfo.AikidoId,
                IsActive = member.IsActive
            };

        }
    }
}