using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DojoDbContext _context;

        public OrganizationRepository(DojoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Organization organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
        }

        public async Task<Organization?> GetByIdAsync(int id) =>
            await _context.Organizations.FindAsync(id);

        public async Task<List<Organization>> GetAllAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null) return;
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }

    }
}