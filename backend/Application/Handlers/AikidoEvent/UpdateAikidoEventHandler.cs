using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.AikidoEvent;
using Domain.Interfaces;

namespace Application.Handlers.AikidoEvent
{
    public class UpdateAikidoEventHandler
    {
        private readonly IAikidoEventRepository _repo;

        public UpdateAikidoEventHandler(IAikidoEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateAikidoEventCommand cmd)
        {
            var aikidoEvent = await _repo.GetByIdAsync(cmd.Id);
            if (aikidoEvent == null) return false;

            aikidoEvent.Title = cmd.Title;
            aikidoEvent.Type = cmd.Type;
            aikidoEvent.Date = cmd.Date;
            aikidoEvent.Address = cmd.Address;
            aikidoEvent.Contact = cmd.Contact;
            aikidoEvent.Description = cmd.Description;
            aikidoEvent.OrganizerId = cmd.OrganizerId;
            aikidoEvent.PresenterId = cmd.PresenterId;

            await _repo.UpdateAsync(aikidoEvent);
            return true;
        } 
    }
}