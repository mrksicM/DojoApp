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
                    Street = d.Address?.Street ?? "",
                    StreetNumber = d.Address?.StreetNumber ?? "",
                    City = d.Address?.City ?? "",
                    Country = d.Address?.Country ?? "",
                    Email = d.Contact?.Email ?? "",
                    PhoneNumber = d.Contact?.PhoneNumber ?? "",
                    DojoChoId = d.DojoChoId,
                    Members = d.Members.Select(m => new MembersDTO
                    {
                        Id = m.Id,
                        FirstName = m.Name.FirstName,
                        LastName = m.Name.LastName,
                        DateOfBirth = m.PersonalInfo.DateOfBirth,
                        Email = m.PersonalInfo.Contact?.Email ?? "",
                        PhoneNumber = m.PersonalInfo.Contact?.PhoneNumber ?? "",
                        Street = m.PersonalInfo.Address?.Street ?? "",
                        StreetNumber = m.PersonalInfo.Address?.StreetNumber ?? "",
                        City = m.PersonalInfo.Address?.City ?? "",
                        Country = m.PersonalInfo.Address?.Country ?? "",
                        ParentFirstName = m.PersonalInfo.ParentName?.FirstName,
                        ParentLastName = m.PersonalInfo.ParentName?.LastName,
                        IsActive = m.IsActive
                    }).ToList()
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
                    Street = d.Address?.Street ?? "",
                    StreetNumber = d.Address?.StreetNumber ?? "",
                    City = d.Address?.City ?? "",
                    Country = d.Address?.Country ?? "",
                    Email = d.Contact?.Email ?? "",
                    PhoneNumber = d.Contact?.PhoneNumber ?? "",
                    DojoChoId = d.DojoChoId
                }).ToList()
            }).ToList();
        }
    }
}