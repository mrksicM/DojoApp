using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Queries.Dojos;
using Domain.Interfaces;

namespace Application.Handlers.Dojos
{
    public class GetDojoHandler
    {
        private readonly IDojoRepository _repo;

        public GetDojoHandler(IDojoRepository repo)
        {
            _repo = repo;
        }

        public async Task<DojoDTO?> Handle(GetDojoByIdQuery query)
        {
            var dojo = await _repo.GetByIdAsync(query.Id);
            if (dojo == null) return null;

            // Map domain entity -> DTO
            return new DojoDTO
            {
                Id = dojo.Id,
                Name = dojo.Name,
                Street = dojo.Address.Street,
                StreetNumber = dojo.Address.StreetNumber,
                City = dojo.Address.City,
                Country = dojo.Address.Country,
                Email = dojo.Contact.Email,
                PhoneNumber = dojo.Contact.PhoneNumber,
                DojoChoId = dojo.DojoChoId,
                DojoChoName = dojo.DojoCho?.Name is { FirstName: var firstName, LastName: var lastName }
                    ? $"{firstName} {lastName}"
                    : null!,
                Members = dojo.Members.Select(m => new MembersDTO
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
                    Rank = m.TraineeInfo.Rank,
                    Belt = m.TraineeInfo.Belt,
                    Role = m.TraineeInfo.Role,
                    DateOfJoining = m.TraineeInfo.DateOfJoining,
                    AikidoId = m.TraineeInfo.AikidoId,
                    IsActive = m.IsActive
                }).ToList()
            };
        }

        public async Task<IEnumerable<DojoDTO>> Handle(GetAllDojosQuery query)
        {
            var dojos = await _repo.GetAllAsync();
            // Map domain entities -> DTOs
            return dojos.Select(d => new DojoDTO
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
                    Rank = m.TraineeInfo.Rank,
                    Belt = m.TraineeInfo.Belt,
                    Role = m.TraineeInfo.Role,
                    DateOfJoining = m.TraineeInfo.DateOfJoining,
                    AikidoId = m.TraineeInfo.AikidoId,
                    IsActive = m.IsActive
                }).ToList()
            });
        }
    }
}