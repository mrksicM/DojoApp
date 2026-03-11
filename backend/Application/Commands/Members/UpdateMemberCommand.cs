using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Members
{
    public record UpdateMemberCommand(int Id, Name Name, PersonalInfo PersonalInfo, TraineeInfo TraineeInfo, bool IsActive);
}