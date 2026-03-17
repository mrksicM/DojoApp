using Application.Commands.Dojo;
using Domain.Interfaces;

namespace Application.Handlers.Dojo
{
    public class DeleteDojoHandler
    {
        private readonly IDojoRepository _repo;

        public DeleteDojoHandler(IDojoRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteDojoCommand cmd)
        {
            await _repo.DeleteAsync(cmd.Id);
        }
    }
}