using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDojoRepository
    {
        Task AddAsync(Dojo dojo);
        Task<Dojo?> GetByIdAsync(int id);
        Task<List<Dojo>> GetAllAsync();
        Task UpdateAsync(Dojo dojo);
        Task DeleteAsync(int id);
    }
}