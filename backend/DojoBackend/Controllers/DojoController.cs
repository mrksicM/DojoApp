using Application.Commands.Dojo;
using Application.DTOs;
using Application.Handlers.Dojos;
using Application.Queries.Dojos;
using Microsoft.AspNetCore.Mvc;
namespace DojoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DojoController : ControllerBase
    {

        private readonly CreateDojoHandler _createHandler;
        private readonly GetDojoHandler _getHandler;
        private readonly DeleteDojoHandler _deleteHandler;
        private readonly UpdateDojoHandler _updateHandler;

        public DojoController(CreateDojoHandler createHandler, GetDojoHandler getByIdHandler, DeleteDojoHandler deleteHandler, UpdateDojoHandler updateHandler)
        {
            _createHandler = createHandler;
            _getHandler = getByIdHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        // [HttpPost]
        // public async Task<IActionResult> Create(DojoDTO dto)
        // {
        //     var dojo = await _createHandler.Handle(new CreateDojoCommand(dto));
        //     return CreatedAtAction(nameof(GetById), new { id = dojo.Id }, dojo);
        // }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DojoDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cmd = new CreateDojoCommand(dto);
            var created = await _createHandler.Handle(cmd);

            if (created == null) return BadRequest();

            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dojo = await _getHandler.Handle(new GetDojoByIdQuery(id));
            if (dojo == null)
                return NotFound();
            return Ok(dojo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dojos = await _getHandler.Handle(new GetAllDojosQuery());
            return Ok(dojos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dojo = await _getHandler.Handle(new GetDojoByIdQuery(id));
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
                dto.Street,
                dto.StreetNumber,
                dto.City,
                dto.Country ?? "",
                dto.Email,
                dto.PhoneNumber,
                dto.DojoChoId,
                dto.DojoChoName,
                dto.Members
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return Ok(dto);
        }

        // GET /api/dojo/{id}/members
        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetMembers(int id)
        {
            var dojo = await _getHandler.Handle(new GetDojoByIdQuery(id));

            if (dojo == null)
                return NotFound();

            var members = dojo.Members.Select(m => new MembersDTO
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                DateOfBirth = m.DateOfBirth,
                Email = m.Email ?? "",
                PhoneNumber = m.PhoneNumber ?? "",
                Street = m.Street ?? "",
                StreetNumber = m.StreetNumber ?? "",
                City = m.City ?? "",
                Country = m.Country ?? "",
                ParentFirstName = m.ParentFirstName ?? "",
                ParentLastName = m.ParentLastName ?? "",
                IsActive = m.IsActive
            }).ToList();

            return Ok(members);
        }
    }
}