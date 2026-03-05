using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PersonalInfo
    {
        public required Address Address { get; set; }
        public required Contact Contact { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public Name? ParentName { get; set; } // Optional, only for children
        
    }
}