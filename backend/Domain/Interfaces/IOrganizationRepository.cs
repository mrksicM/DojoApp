using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrganizationRepository
    {
        Task AddAsync(Organization organization);
        Task<Organization?> GetByIdAsync(int id);
        Task<List<Organization>> GetAllAsync();
        Task UpdateAsync(Organization organization);
        Task DeleteAsync(int id);
    }
}