using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Dojo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Contact Contact { get; set; }
        public required Address Address { get; set; }
        public required int DojoChoId { get; set; }
        public List<Member> Members { get; set; } = new();
    }
}