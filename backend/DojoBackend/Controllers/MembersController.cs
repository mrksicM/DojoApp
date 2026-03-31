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
        private readonly GetMemberHandler _getMemberHandler;
        private readonly DeleteMemberHandler _deleteHandler;
        private readonly UpdateMemberHandler _updateHandler;

        public MembersController(CreateMemberHandler createHandler, GetMemberHandler getMemberHandler, DeleteMemberHandler deleteHandler, UpdateMemberHandler updateHandler)
        {
            _createHandler = createHandler;
            _getMemberHandler = getMemberHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MembersDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cmd = new CreateMemberCommand(dto);
            var created = await _createHandler.Handle(cmd);

            if (created == null) return BadRequest();

            return Ok(created);


        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var members = await _getMemberHandler.Handle(new GetAllMembersQuery());

            var dtos = members.Select(m => new MembersDTO
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Street = m.Street,
                StreetNumber = m.StreetNumber.ToString(),
                City = m.City,
                Country = m.Country,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                DateOfBirth = m.DateOfBirth,
                Rank = m.Rank,
                Belt = m.Belt,
                Role = m.Role,
                DateOfJoining = m.DateOfJoining,
                AikidoId = m.AikidoId,
                IsActive = m.IsActive
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _getMemberHandler.Handle(new GetMemberByIdQuery(id));
            if (member == null)
                return NotFound();
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _getMemberHandler.Handle(new GetMemberByIdQuery(id));
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
                new Name { FirstName = dto.FirstName, LastName = dto.LastName },
                new PersonalInfo
                {
                    Address = new Address
                    {
                        Street = dto.Street ?? string.Empty,
                        StreetNumber = dto.StreetNumber ?? string.Empty,
                        City = dto.City ?? string.Empty,
                        Country = dto.Country ?? string.Empty
                    },
                    Contact = new Contact
                    {
                        Email = dto.Email ?? string.Empty,
                        PhoneNumber = dto.PhoneNumber ?? string.Empty
                    }, // Handle missing contact info
                    DateOfBirth = dto.DateOfBirth,
                    ParentName = dto.ParentFirstName != null && dto.ParentLastName != null
                        ? new Name { FirstName = dto.ParentFirstName, LastName = dto.ParentLastName }
                        : null
                },
                new TraineeInfo
                {
                    Rank = dto.Rank,
                    Belt = dto.Belt,
                    Role = dto.Role,
                    DateOfJoining = dto.DateOfJoining,
                    Notes = dto.NoteContent != null
                        ? new List<Note> { new Note { Content = dto.NoteContent, CreatedAt = dto.NoteCreatedAt, CreatedByMemberId = dto.NoteCreatedByMemberId } }
                        : null, // Handle missing notes
                    AikidoId = dto.AikidoId
                },
                dto.IsActive
            );

            var success = await _updateHandler.Handle(cmd);
            if (!success) return NotFound();

            return Ok(dto);
        }
    }
}