using Application.Commands.Members;
using Domain.Interfaces;

namespace Application.Handlers.Members
{
    public class UpdateMemberHandler
    {
        private readonly IMemberRepository _repo;
        public UpdateMemberHandler(IMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(UpdateMemberCommand cmd)
        {
            var member = await _repo.GetByIdAsync(cmd.Id);
            if (member == null) return false;

            // Apply updates from command
            member.Name = cmd.Name;
            member.PersonalInfo = cmd.PersonalInfo;
            member.TraineeInfo = cmd.TraineeInfo;
            member.IsActive = cmd.IsActive;

            await _repo.UpdateAsync(member);
            return true;
        }
    }
}