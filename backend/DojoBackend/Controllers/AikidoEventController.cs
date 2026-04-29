using Application.Commands.AikidoEvent;
using Application.DTOs;
using Application.Handlers.AikidoEvent;
using Application.Queries.AikidoEvents;
using Microsoft.AspNetCore.Mvc;

namespace DojoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AikidoEventController : ControllerBase
    {

        private readonly CreateAikidoEventHandler _createHandler;
        private readonly GetAikidoEventHandler _getHandler;
        private readonly DeleteAikidoEventHandler _deleteHandler;
        private readonly UpdateAikidoEventHandler _updateHandler;

        public AikidoEventController(CreateAikidoEventHandler createHandler, GetAikidoEventHandler getByIdHandler, DeleteAikidoEventHandler deleteHandler, UpdateAikidoEventHandler updateHandler)
        {
            _createHandler = createHandler;
            _getHandler = getByIdHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AikidoEventDTO dto)
        {
            var aikidoEvent = await _createHandler.Handle(new CreateAikidoEventCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = aikidoEvent.Id }, aikidoEvent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var aikidoEvents = await _getHandler.Handle(new GetAllAikidoEventsQuery());
            return Ok(aikidoEvents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aikidoEvent = await _getHandler.Handle(new GetAikidoEventByIdQuery(id));
            if (aikidoEvent == null)
                return NotFound();
            return Ok(aikidoEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aikidoEvent = await _getHandler.Handle(new GetAikidoEventByIdQuery(id));
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
                dto.Street,
                dto.StreetNumber,
                dto.City,
                dto.Country,
                dto.Email,
                dto.PhoneNumber,
                dto.Description,
                dto.OrganizerId,
                dto.PresenterId
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return NoContent();
        }

    }
}