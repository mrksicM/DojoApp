using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Interfaces
{
    public interface IMembersService
    {
        Task<IEnumerable<Member>> GetMembersOfDojo(int dojoId);
    }
}