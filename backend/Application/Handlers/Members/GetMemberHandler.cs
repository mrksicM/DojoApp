using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Members;
using Application.DTOs;
using Application.Queries.Members;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Handlers.Members
{
    public class GetMemberHandler
    {
        private readonly IMemberRepository _repo;

        public GetMemberHandler(IMemberRepository repo)
        {
            _repo = repo;
        }

        public async Task<MembersDTO?> Handle(GetMemberByIdQuery query)
        {
            var member = await _repo.GetByIdAsync(query.Id);
            if (member == null) return null;

            // Map domain entity -> DTO
            return new MembersDTO
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
                Rank = member.TraineeInfo.Rank,
                Belt = member.TraineeInfo.Belt,
                Role = member.TraineeInfo.Role,
                DateOfJoining = member.TraineeInfo.DateOfJoining,
                AikidoId = member.TraineeInfo.AikidoId,
                IsActive = member.IsActive
            };

        }

        public async Task<IEnumerable<MembersDTO>> Handle(GetAllMembersQuery getAllMembersQuery)
        {
            var members = await _repo.GetAllAsync();
            // Map domain entities -> DTOs
            var membersDTO = members.Select(m => new MembersDTO
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
                IsActive = m.IsActive,
                NoteContent = m.TraineeInfo.Notes != null ? string.Join("; ", m.TraineeInfo.Notes.Select(n => n.Content)) : string.Empty,
                NoteCreatedAt = m.TraineeInfo.Notes != null && m.TraineeInfo.Notes.Any() ? m.TraineeInfo.Notes.First().CreatedAt : DateTime.MinValue,
                NoteCreatedByMemberId = m.TraineeInfo.Notes != null && m.TraineeInfo.Notes.Any() ? m.TraineeInfo.Notes.First().CreatedByMemberId : 0,
                // Notes = m.TraineeInfo.Notes.Select(n => new NoteDTO
                // {
                //     Content = n.Content,
                //     CreatedAt = n.CreatedAt,
                //     CreatedByMemberId = n.CreatedByMemberId
                // }).ToList() ?? new List<NoteDTO>()

            }).ToList();

            return membersDTO;
        }
    }
}