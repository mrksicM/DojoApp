using Application.Commands.Dojo;
using Domain.Interfaces;

namespace Application.Handlers.Dojo
{
    public class UpdateDojoHandler
    {
        private readonly IDojoRepository _repo;

        public UpdateDojoHandler(IDojoRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateDojoCommand cmd)
        {
            var dojo = await _repo.GetByIdAsync(cmd.Id);
            if (dojo == null) return false;

            dojo.Name = cmd.Name;
            dojo.Contact = cmd.Contact;
            dojo.Address = cmd.Address;
            dojo.DojoChoId = cmd.DojoChoId;

            await _repo.UpdateAsync(dojo);
            return true;
        }   

    }
}