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
            aikidoEvent.Address = new Domain.ValueObjects.Address
            {
                Street = cmd.Street ?? string.Empty,
                StreetNumber = cmd.StreetNumber ?? string.Empty,
                City = cmd.City ?? string.Empty,
                Country = cmd.Country ?? string.Empty
            };
            aikidoEvent.Contact = new Domain.ValueObjects.Contact
            {
                Email = cmd.Email ?? string.Empty,
                PhoneNumber = cmd.PhoneNumber ?? string.Empty
            };
            aikidoEvent.Description = cmd.Description ?? string.Empty;
            aikidoEvent.OrganizerId = cmd.OrganizerId;
            aikidoEvent.PresenterId = cmd.PresenterId;

            await _repo.UpdateAsync(aikidoEvent);
            return true;
        }
    }
}