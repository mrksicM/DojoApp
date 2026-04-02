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
                Street = organization.Address?.Street ?? "",
                StreetNumber = organization.Address?.StreetNumber ?? "",
                City = organization.Address?.City ?? "",
                Country = organization.Address?.Country,
                Email = organization.Contact?.Email ?? "",
                PhoneNumber = organization.Contact?.PhoneNumber ?? "",
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

        public async Task<IEnumerable<OrganizationDTO>> Handle(GetAllOrganizationsQuery query)
        {
            var organizations = await _repo.GetAllAsync();
            // Map domain entities -> DTOs
            return organizations.Select(organization => new OrganizationDTO
            {
                Id = organization.Id,
                Name = organization.Name,
                PresidentId = organization.PresidentId,
                Street = organization.Address?.Street ?? "",
                StreetNumber = organization.Address?.StreetNumber ?? "",
                City = organization.Address?.City ?? "",
                Country = organization.Address?.Country,
                Email = organization.Contact?.Email ?? "",
                PhoneNumber = organization.Contact?.PhoneNumber ?? "",
                Dojos = organization.Dojos.Select(d => new DojoDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Contact = d.Contact,
                    Address = d.Address,
                    DojoChoId = d.DojoChoId
                }).ToList()
            }).ToList();
        }
    }
}