using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Dojo;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Handlers.Dojos
{
    public class CreateDojoHandler
    {
        private readonly IDojoRepository _repository;
        public CreateDojoHandler(IDojoRepository repository)
        {
            _repository = repository;
        }
        public async Task<DojoDTO?> Handle(CreateDojoCommand cmd)
        {
            // Find the dojo-cho member by ID
            var dojoChoMember = cmd.DojoDTO.Members.FirstOrDefault(m => m.Id == cmd.DojoDTO.DojoChoId);

            var dojo = new Dojo()
            {
                Name = cmd.DojoDTO.Name,
                Address = new Domain.ValueObjects.Address()
                {
                    Street = cmd.DojoDTO.Street,
                    StreetNumber = cmd.DojoDTO.StreetNumber,
                    City = cmd.DojoDTO.City,
                    Country = cmd.DojoDTO.Country
                },
                Contact = new Domain.ValueObjects.Contact()
                {
                    Email = cmd.DojoDTO.Email,
                    PhoneNumber = cmd.DojoDTO.PhoneNumber
                },
                DojoChoId = cmd.DojoDTO.DojoChoId,
                DojoCho = dojoChoMember != null
                    ? new Member()
                    {
                        Name = new Domain.ValueObjects.Name(dojoChoMember?.FirstName ?? "", dojoChoMember?.LastName ?? ""),
                        PersonalInfo = new Domain.ValueObjects.PersonalInfo
                        {
                            Address = new Domain.ValueObjects.Address
                            {
                                Street = dojoChoMember?.Street ?? "",
                                StreetNumber = dojoChoMember?.StreetNumber ?? "",
                                City = dojoChoMember?.City ?? "",
                                Country = dojoChoMember?.Country ?? ""
                            },
                            Contact = new Domain.ValueObjects.Contact
                            {
                                Email = dojoChoMember?.Email ?? "",
                                PhoneNumber = dojoChoMember?.PhoneNumber ?? ""
                            },
                            DateOfBirth = dojoChoMember?.DateOfBirth ?? DateOnly.FromDateTime(DateTime.Now),
                            ParentName = null
                        },
                        TraineeInfo = new Domain.ValueObjects.TraineeInfo
                        {
                            Rank = dojoChoMember?.Rank ?? 0,
                            Belt = dojoChoMember?.Belt ?? "None",
                            Role = "DojoCho",
                            DateOfJoining = DateTime.Now,
                            AikidoId = dojoChoMember?.AikidoId ?? ""
                        },
                        IsActive = true
                    }
                    : null!,
                Members = cmd.DojoDTO.Members.Select(m => new Member()
                {
                    Name = new Domain.ValueObjects.Name(m.FirstName, m.LastName),
                    PersonalInfo = new Domain.ValueObjects.PersonalInfo
                    {
                        Address = new Domain.ValueObjects.Address
                        {
                            Street = m.Street,
                            StreetNumber = m.StreetNumber,
                            City = m.City,
                            Country = m.Country
                        },
                        Contact = new Domain.ValueObjects.Contact
                        {
                            Email = m.Email,
                            PhoneNumber = m.PhoneNumber
                        },
                        DateOfBirth = m.DateOfBirth,
                        ParentName = m.ParentFirstName != null && m.ParentLastName != null
                            ? new Domain.ValueObjects.Name(m.ParentFirstName, m.ParentLastName)
                            : null
                    },
                    TraineeInfo = new Domain.ValueObjects.TraineeInfo
                    {
                        Rank = m.Rank,
                        Belt = m.Belt,
                        Role = m.Role,
                        DateOfJoining = m.DateOfJoining,
                        AikidoId = m.AikidoId
                    },
                    IsActive = m.IsActive
                }).ToList()
            };

            await _repository.AddAsync(dojo);

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
                    ParentFirstName = m.PersonalInfo.ParentName?.FirstName,
                    ParentLastName = m.PersonalInfo.ParentName?.LastName,
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