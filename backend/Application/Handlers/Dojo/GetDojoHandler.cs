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
                    Name = m.Name,
                    PersonalInfo = m.PersonalInfo,
                    TraineeInfo = m.TraineeInfo
                }).ToList()
            };
        }
    }
}