using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Organization;
using Application.DTOs;
using Application.Handlers.Organization;
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
            var organization = await _getByIdHandler.Handle(new GetOrganizationCommand(id));
            if (organization == null)
                return NotFound();
            return Ok(organization);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _getByIdHandler.Handle(new GetOrganizationCommand(id));
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
                dto.Contact,
                dto.Address,
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

            return NoContent();
        }


    }
}