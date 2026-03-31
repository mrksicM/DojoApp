using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.ValueObjects
{
    public class TraineeInfo
    {
        public required int Rank { get; set; }
        public required string Belt { get; set; }
        public required string Role { get; set; }
        public DateTime DateOfJoining { get; set; }
        public List<Note>? Notes { get; set; }
        public required string AikidoId { get; set; }

        public TraineeInfo() { }

        public TraineeInfo(int rank, string belt, string role, DateTime dateOfJoining, List<Note>? notes, string aikidoId)
        {
            Rank = rank;
            Belt = belt;
            Role = role;
            DateOfJoining = dateOfJoining;
            Notes = notes;
            AikidoId = aikidoId;
        }
    }
}