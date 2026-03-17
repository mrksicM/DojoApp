using Application.Commands.Members;
using Application.DTOs;
using Application.Handlers.Members;
using Application.Queries.Members;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace DojoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly CreateMemberHandler _createHandler;
        private readonly GetMemberHandler _getByIdHandler;
        private readonly DeleteMemberHandler _deleteHandler;
        private readonly UpdateMemberHandler _updateHandler;

        public MembersController(CreateMemberHandler createHandler, GetMemberHandler getByIdHandler, DeleteMemberHandler deleteHandler, UpdateMemberHandler updateHandler)
        {
            _createHandler = createHandler;
            _getByIdHandler = getByIdHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembersDTO dto)
        {
            var member = await _createHandler.Handle(new CreateMemberCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _getByIdHandler.Handle(new GetMemberByIdQuery(id));
            if (member == null)                
                return NotFound();
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _getByIdHandler.Handle(new GetMemberByIdQuery(id));
            if (member == null)
                return NotFound();
            await _deleteHandler.Handle(new DeleteMemberCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MembersDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var cmd = new UpdateMemberCommand(
                dto.Id,
                // Fix: use object initializer if your Name VO has required properties
                new Name { FirstName = dto.Name.FirstName, LastName = dto.Name.LastName },
                new PersonalInfo
                {
                    Address = dto.PersonalInfo.Address,
                    Contact = dto.PersonalInfo.Contact,
                    DateOfBirth = dto.PersonalInfo.DateOfBirth,
                    ParentName = dto.PersonalInfo.ParentName
                },
                new TraineeInfo
                {
                    Rank = dto.TraineeInfo.Rank,
                    Belt = dto.TraineeInfo.Belt,
                    Role = dto.TraineeInfo.Role,
                    DateOfJoining = dto.TraineeInfo.DateOfJoining,
                    Notes = dto.TraineeInfo.Notes,
                    AikidoId = dto.TraineeInfo.AikidoId,
                    DojoId = dto.TraineeInfo.DojoId
                },
                dto.IsActive
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return NoContent();
        }
    }

}