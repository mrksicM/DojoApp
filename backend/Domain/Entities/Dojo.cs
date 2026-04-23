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
        public Member DojoCho { get; set; }
        public List<Member> Members { get; set; } = new();

        public Dojo()
        {

        }

        public Dojo(int id, string name, Contact contact, Address address, List<Member> members, int dojoChoId, Member dojoCho)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Address = address;
            Members = members;
            DojoChoId = dojoChoId;
            DojoCho = dojoCho;
        }
    }
}