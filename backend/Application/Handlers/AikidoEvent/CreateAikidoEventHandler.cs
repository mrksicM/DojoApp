using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var dto = cmd.aikidoEventDTO;
            var aikidoEvent = new Domain.Entities.AikidoEvent()
            {
                Id = dto.Id,
                Title = dto.Title,
                Type = dto.Type,
                Date = dto.Date,
                Address = dto.Address,
                Contact = dto.Contact,
                Description = dto.Description,
                OrganizerId = dto.OrganizerId,
                PresenterId = dto.PresenterId,
                AttendeesIds = dto.AttendeesIds
            };
            await _repo.AddAsync(aikidoEvent);
            return new AikidoEventDTO()
            {
                Id = aikidoEvent.Id,
                Title = aikidoEvent.Title,
                Type = aikidoEvent.Type,
                Date = aikidoEvent.Date,
                Address = aikidoEvent.Address,
                Contact = aikidoEvent.Contact,
                Description = aikidoEvent.Description,
                OrganizerId = aikidoEvent.OrganizerId,
                PresenterId = aikidoEvent.PresenterId,
                AttendeesIds = aikidoEvent.AttendeesIds
            };
        }
    }
}