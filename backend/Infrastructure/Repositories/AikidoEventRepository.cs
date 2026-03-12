using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AikidoEventRepository : IAikidoEventRepository
    {
        private readonly DojoDbContext _context;

        public AikidoEventRepository(DojoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AikidoEvent aikidoEvent)
        {
            _context.AikidoEvents.Add(aikidoEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<AikidoEvent?> GetByIdAsync(int id) =>
            await _context.AikidoEvents.FindAsync(id);

        public async Task<List<AikidoEvent>> GetAllAsync()
        {
            return await _context.AikidoEvents.ToListAsync();
        }

        public async Task UpdateAsync(AikidoEvent aikidoEvent)
        {
            _context.AikidoEvents.Update(aikidoEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aikidoEvent = await _context.AikidoEvents.FindAsync(id);
            if (aikidoEvent == null) return;
            _context.AikidoEvents.Remove(aikidoEvent);
            await _context.SaveChangesAsync();
        }
    }
}