using Application.Commands.Dojo;
using Application.DTOs;
using Application.Handlers.Dojo;
using Application.Queries.Dojos;
using Microsoft.AspNetCore.Mvc;
namespace DojoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DojoController : ControllerBase
    {

        private readonly CreateDojoHandler _createHandler;
        private readonly GetDojoHandler _getByIdHandler;
        private readonly DeleteDojoHandler _deleteHandler;
        private readonly UpdateDojoHandler _updateHandler;

        public DojoController(CreateDojoHandler createHandler, GetDojoHandler getByIdHandler, DeleteDojoHandler deleteHandler, UpdateDojoHandler updateHandler)
        {
            _createHandler = createHandler;
            _getByIdHandler = getByIdHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DojoDTO dto)
        {
            var dojo = await _createHandler.Handle(new CreateDojoCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = dojo.Id }, dojo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dojo = await _getByIdHandler.Handle(new GetDojoByIdQuery(id));
            if (dojo == null)                
                return NotFound();
            return Ok(dojo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dojo = await _getByIdHandler.Handle(new GetDojoByIdQuery(id));
            if (dojo == null)
                return NotFound();
            await _deleteHandler.Handle(new DeleteDojoCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DojoDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var cmd = new UpdateDojoCommand(
                dto.Id,
                dto.Name,
                dto.Contact,
                dto.Address,
                dto.DojoChoId,
                dto.Members
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}