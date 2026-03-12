using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DojoRepository : IDojoRepository
    {

        private readonly DojoDbContext _context;

        public DojoRepository(DojoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Dojo dojo)
        {
            _context.Dojos.Add(dojo);
            await _context.SaveChangesAsync();
        }

        public async Task<Dojo?> GetByIdAsync(int id) =>
            await _context.Dojos.FindAsync(id);

        public async Task<List<Dojo>> GetAllAsync()
        {
            return await _context.Dojos.ToListAsync();
        }

        public async Task UpdateAsync(Dojo dojo)
        {
            _context.Dojos.Update(dojo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dojo = await _context.Dojos.FindAsync(id);
            if (dojo == null) return;
            _context.Dojos.Remove(dojo);
            await _context.SaveChangesAsync();
        }
    }
}