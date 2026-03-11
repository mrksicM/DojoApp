using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
        Task<Member?> GetByIdAsync(int id);
        Task<List<Member>> GetAllAsync();
        Task UpdateAsync(Member member);
        Task DeleteAsync(int id);
    }
}