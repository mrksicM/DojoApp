using Application.DTOs;
using Application.Queries.Organizations;
using Domain.Interfaces;

namespace Application.Handlers.Organization
{
    public class GetOrganizationHandler
    {
        private readonly IOrganizationRepository _repo;

        public GetOrganizationHandler(IOrganizationRepository repo)
        {
            _repo = repo;
        }

        public async Task<OrganizationDTO?> Handle(GetOrganizationByIdQuery query)
        {
            var organization = await _repo.GetByIdAsync(query.Id);
            if (organization == null) return null;

            // Map domain entity -> DTO
            return new OrganizationDTO
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
                    DojoChoId = d.DojoChoId
                }).ToList()
            };

        }
        
    }
}