using Application.Commands.Members;
using Domain.Interfaces;

namespace Application.Handlers.Members
{
    public class DeleteMemberHandler
    {
        private readonly IMemberRepository _repo;

        public DeleteMemberHandler(IMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(DeleteMemberCommand cmd)
        {
            await _repo.DeleteAsync(cmd.Id);
        }
    }
}