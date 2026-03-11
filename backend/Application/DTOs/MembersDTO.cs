using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public class MembersDTO
    {
        public int Id { get; set; }
        public required Name Name { get; set; }
        public required PersonalInfo PersonalInfo { get; set; }
        public required TraineeInfo TraineeInfo { get; set; }
        public bool IsActive { get; set; } = true;

        public MembersDTO() { }

        public MembersDTO(int id,Name name, PersonalInfo personalInfo, TraineeInfo traineeInfo, bool isActive = true)
        {
            Id = id;
            Name = name;
            PersonalInfo = personalInfo;
            TraineeInfo = traineeInfo;
            IsActive = isActive;
        }

        public MembersDTO(Name name, PersonalInfo personalInfo, TraineeInfo traineeInfo, bool isActive = true)
        {
            Name = name;
            PersonalInfo = personalInfo;
            TraineeInfo = traineeInfo;
            IsActive = isActive;
        }

        public MembersDTO(Member member)
        {
            Id = member.Id;
            Name = member.Name;
            PersonalInfo = member.PersonalInfo;
            TraineeInfo = member.TraineeInfo;
            IsActive = member.IsActive;
        }
    }
}
