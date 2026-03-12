using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Members;
using Application.Commands.Organization;
using Application.DTOs;
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

        public async Task<OrganizationDTO?> Handle(GetOrganizationCommand cmd)
        {
            var organization = await _repo.GetByIdAsync(cmd.Id);
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