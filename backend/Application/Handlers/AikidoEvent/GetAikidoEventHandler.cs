using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.AikidoEvent;
using Application.DTOs;
using Application.Queries.AikidoEvents;
using Domain.Interfaces;

namespace Application.Handlers.AikidoEvent
{
    public class GetAikidoEventHandler
    {        
        private readonly IAikidoEventRepository _repo;

        public GetAikidoEventHandler(IAikidoEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<AikidoEventDTO?> Handle(GetAikidoEventByIdQuery query)
        {
            var aikidoEvent = await _repo.GetByIdAsync(query.Id);
            if (aikidoEvent == null) return null;
            return new AikidoEventDTO
            {
                Id = aikidoEvent.Id,
                Title = aikidoEvent.Title,
                Type = aikidoEvent.Type,
                Date = aikidoEvent.Date,
                Address = aikidoEvent.Address,
                Contact = aikidoEvent.Contact,
                Description = aikidoEvent.Description,
                OrganizerId = aikidoEvent.OrganizerId,
                PresenterId = aikidoEvent.PresenterId
            };
        }
    }
}