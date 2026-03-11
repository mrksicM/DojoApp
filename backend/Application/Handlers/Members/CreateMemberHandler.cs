using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var dto = cmd.memberDTO;
            var member = new Member()
            {
                Name = dto.Name,
                PersonalInfo = dto.PersonalInfo,
                TraineeInfo = dto.TraineeInfo,
                IsActive = dto.IsActive
            };
            await _repo.AddAsync(member);
            return new MembersDTO()
            {
                Name = member.Name,
                PersonalInfo = member.PersonalInfo,
                TraineeInfo = member.TraineeInfo,
                IsActive = member.IsActive
            };

        }
    }
}