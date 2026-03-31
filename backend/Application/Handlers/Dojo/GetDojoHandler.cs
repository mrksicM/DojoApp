using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Dojo;
using Application.DTOs;
using Application.Queries.Dojos;
using Domain.Interfaces;

namespace Application.Handlers.Dojo
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
            return new DojoDTO
            {
                Id = dojo.Id,
                Name = dojo.Name,
                Contact = dojo.Contact,
                Address = dojo.Address,
                DojoChoId = dojo.DojoChoId,
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
    }
}