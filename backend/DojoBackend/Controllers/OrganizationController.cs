using Application.Commands.Organization;
using Application.DTOs;
using Application.Handlers.Organization;
using Application.Queries.Organizations;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace DojoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly CreateOrganizationHandler _createHandler;
        private readonly GetOrganizationHandler _getByIdHandler;
        private readonly DeleteOrganizationHandler _deleteHandler;
        private readonly UpdateOrganizationHandler _updateHandler;

        public OrganizationController(CreateOrganizationHandler createHandler, GetOrganizationHandler getByIdHandler, DeleteOrganizationHandler deleteHandler, UpdateOrganizationHandler updateHandler)
        {
            _createHandler = createHandler;
            _getByIdHandler = getByIdHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrganizationDTO dto)
        {
            var organization = await _createHandler.Handle(new CreateOrganizationCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = organization.Id }, organization);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var organization = await _getByIdHandler.Handle(new GetOrganizationByIdQuery(id));
            if (organization == null)
                return NotFound();
            return Ok(organization);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _getByIdHandler.Handle(new GetOrganizationByIdQuery(id));
            if (organization == null)
                return NotFound();
            await _deleteHandler.Handle(new DeleteOrganizationCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrganizationDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var cmd = new UpdateOrganizationCommand(
                dto.Id,
                dto.Name,
                dto.PresidentId,
                new Contact
                {
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                },
                new Address
                {
                    Street = dto.Street,
                    StreetNumber = dto.StreetNumber,
                    City = dto.City,
                    Country = dto.Country
                },
                dto.Dojos.Select(d => new DojoDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Contact = d.Contact,
                    Address = d.Address,
                    DojoChoId = d.DojoChoId
                }).ToList()
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var organizations = await _getByIdHandler.Handle(new GetAllOrganizationsQuery());

            var dtos = organizations.Select(organization => new OrganizationDTO
            {
                Id = organization.Id,
                Name = organization.Name,
                PresidentId = organization.PresidentId,
                Street = organization.Street ?? "",
                StreetNumber = organization.StreetNumber ?? "",
                City = organization.City ?? "",
                Country = organization.Country,
                Email = organization.Email ?? "",
                PhoneNumber = organization.PhoneNumber ?? "",
                Dojos = organization.Dojos.Select(d => new DojoDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Contact = d.Contact,
                    Address = d.Address,
                    DojoChoId = d.DojoChoId
                }).ToList()
            }).ToList();

            return Ok(dtos);
        }

    }
}