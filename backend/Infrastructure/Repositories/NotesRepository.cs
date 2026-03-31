using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Domain.Interfaces;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly DojoDbContext _context;
        public NotesRepository(DojoDbContext context) => _context = context;

    }
}