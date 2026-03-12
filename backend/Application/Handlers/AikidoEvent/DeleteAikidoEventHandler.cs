using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.AikidoEvent;
using Domain.Interfaces;

namespace Application.Handlers.AikidoEvent
{
    public class DeleteAikidoEventHandler
    {
        private readonly IAikidoEventRepository _repo;

        public DeleteAikidoEventHandler(IAikidoEventRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteAikidoEventCommand command)
        {
            var aikidoEvent = await _repo.GetByIdAsync(command.id);
            if (aikidoEvent == null) return;
            await _repo.DeleteAsync(aikidoEvent.Id);
        }
    }
}