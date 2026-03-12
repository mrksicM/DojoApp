using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.AikidoEvent;
using Application.Commands.Dojo;
using Application.DTOs;
using Application.Handlers.AikidoEvent;
using Microsoft.AspNetCore.Mvc;

namespace DojoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AikidoEventController: ControllerBase
    {

        private readonly CreateAikidoEventHandler _createHandler;
        private readonly GetAikidoEventHandler _getByIdHandler;
        private readonly DeleteAikidoEventHandler _deleteHandler;
        private readonly UpdateAikidoEventHandler _updateHandler;

        public AikidoEventController(CreateAikidoEventHandler createHandler, GetAikidoEventHandler getByIdHandler, DeleteAikidoEventHandler deleteHandler, UpdateAikidoEventHandler updateHandler)
        {
            _createHandler = createHandler;
            _getByIdHandler = getByIdHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AikidoEventDTO dto)
        {
            var aikidoEvent = await _createHandler.Handle(new CreateAikidoEventCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = aikidoEvent.Id }, aikidoEvent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aikidoEvent = await _getByIdHandler.Handle(new GetAikidoEventCommand(id));
            if (aikidoEvent == null)
                return NotFound();
            return Ok(aikidoEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aikidoEvent = await _getByIdHandler.Handle(new GetAikidoEventCommand(id));
            if (aikidoEvent == null)
                return NotFound();
            await _deleteHandler.Handle(new DeleteAikidoEventCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AikidoEventDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var cmd = new UpdateAikidoEventCommand(
                dto.Id,
                dto.Title,
                dto.Type,
                dto.Date,
                dto.Address,
                dto.Contact,
                dto.Description,
                dto.OrganizerId,
                dto.PresenterId,
                dto.AttendeesIds
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return NoContent();
        }
        
    }
}