using Domain.ValueObjects;

namespace Application.Commands.Members
{
    public record UpdateMemberCommand(int Id, Name Name, PersonalInfo PersonalInfo, TraineeInfo TraineeInfo, bool IsActive);
}