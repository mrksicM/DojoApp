using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public required Name Name { get; set; }
        public required PersonalInfo PersonalInfo { get; set; }
        public required TraineeInfo TraineeInfo { get; set; }
        public bool IsActive { get; set; } = true;
    }
}