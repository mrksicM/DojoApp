using Application.Commands.Organization;
using Application.DTOs;
using Domain.Interfaces;

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
                Contact = dto.Contact,
                Address = dto.Address,
                Dojos = dto.Dojos.Select(d => new Domain.Entities.Dojo
                {
                    Id = d.Id,
                    Name = d.Name,
                    Contact = d.Contact,
                    Address = d.Address,
                    DojoChoId = d.DojoChoId,
                    Members = d.Members.Select(m => new Domain.Entities.Member
                    {
                        Id = m.Id,
                        Name = m.Name,
                        PersonalInfo = m.PersonalInfo,
                        TraineeInfo = m.TraineeInfo,
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
                Contact = organization.Contact,
                Address = organization.Address,
                Dojos = organization.Dojos.Select(d => new DojoDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Contact = d.Contact,
                    Address = d.Address,
                    DojoChoId = d.DojoChoId,
                    Members = d.Members.Select(m => new MembersDTO
                    {
                        Id = m.Id,
                        Name = m.Name,
                        PersonalInfo = m.PersonalInfo,
                        TraineeInfo = m.TraineeInfo,
                        IsActive = m.IsActive
                    }).ToList()
                }).ToList()
            };
        }


    }
}