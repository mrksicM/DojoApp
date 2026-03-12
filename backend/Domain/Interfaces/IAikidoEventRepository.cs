using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAikidoEventRepository
    {

        Task AddAsync(AikidoEvent aikidoEvent);
        Task<AikidoEvent?> GetByIdAsync(int id);
        Task<List<AikidoEvent>> GetAllAsync();
        Task UpdateAsync(AikidoEvent aikidoEvent);
        Task DeleteAsync(int id);
    }
}