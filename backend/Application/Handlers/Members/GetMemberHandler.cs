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
                Name = member.Name,
                PersonalInfo = member.PersonalInfo,
                TraineeInfo = member.TraineeInfo
            };

        }
    }
}