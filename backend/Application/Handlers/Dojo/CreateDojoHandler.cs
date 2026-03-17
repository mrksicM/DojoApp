using Domain.Entities;
using Application.DTOs;
using Domain.Interfaces;
using Application.Commands.Dojo;

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
            var dojo = new Domain.Entities.Dojo()
            {
                Name = dto.Name,
                Contact = dto.Contact,
                Address = dto.Address,
                DojoChoId = dto.DojoChoId,
                Members = dto.Members.Select(m => new Member()
                {
                    Name = m.Name,
                    PersonalInfo = m.PersonalInfo,
                    TraineeInfo = m.TraineeInfo,
                    IsActive = m.IsActive
                }).ToList()
            };
            await _repo.AddAsync(dojo);
            return new DojoDTO()
            {
                Name = dojo.Name,
                Contact = dojo.Contact,
                Address = dojo.Address,
                DojoChoId = dojo.DojoChoId,
                Members = dojo.Members.Select(m => new MembersDTO()
                {
                    Name = m.Name,
                    PersonalInfo = m.PersonalInfo,
                    TraineeInfo = m.TraineeInfo,
                    IsActive = m.IsActive
                }).ToList()
            };
        }
    }
}