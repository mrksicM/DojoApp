using Application.Commands.AikidoEvent;
using Application.DTOs;
using Domain.Interfaces;

namespace Application.Handlers.AikidoEvent
{
    public class CreateAikidoEventHandler
    {
        private readonly IAikidoEventRepository _repo;

        public CreateAikidoEventHandler(IAikidoEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<AikidoEventDTO> Handle(CreateAikidoEventCommand cmd)
        {
            var dto = cmd.AikidoEventDTO;
            var aikidoEvent = new Domain.Entities.AikidoEvent()
            {
                Id = dto.Id,
                Title = dto.Title,
                Type = dto.Type,
                Date = dto.Date,
                Address = new Domain.ValueObjects.Address
                {
                    Street = dto.Street,
                    StreetNumber = dto.StreetNumber,
                    City = dto.City,
                    Country = dto.Country
                },
                Contact = new Domain.ValueObjects.Contact
                {
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                },
                Description = dto.Description,
                OrganizerId = dto.OrganizerId,
                PresenterId = dto.PresenterId
            };
            await _repo.AddAsync(aikidoEvent);
            return new AikidoEventDTO()
            {
                Id = aikidoEvent.Id,
                Title = aikidoEvent.Title,
                Type = aikidoEvent.Type,
                Date = aikidoEvent.Date,
                Street = aikidoEvent.Address.Street,
                StreetNumber = aikidoEvent.Address.StreetNumber,
                City = aikidoEvent.Address.City,
                Country = aikidoEvent.Address.Country,
                Email = aikidoEvent.Contact.Email,
                PhoneNumber = aikidoEvent.Contact.PhoneNumber,
                Description = aikidoEvent.Description,
                OrganizerId = aikidoEvent.OrganizerId,
                PresenterId = aikidoEvent.PresenterId
            };
        }
    }
}