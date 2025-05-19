using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Persistence.Data;
using TANA.Domain.Interface;
using TANA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TANA.Persistence.Repositories
{
    public class BrugerRepository : IBrugerRepository
    {
        private readonly AppDbContext _context;
        public BrugerRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Bruger>> GetAllAsync() => await _context.Brugere.ToListAsync();
        public async Task<Bruger?> GetByIdAsync(int id) => await _context.Brugere.FindAsync(id);
        public async Task AddAsync(Bruger bruger) { _context.Brugere.Add(bruger); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Bruger bruger) { _context.Brugere.Update(bruger); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var bruger = await _context.Brugere.FindAsync(id);
            if (bruger is not null)
            {
                _context.Brugere.Remove(bruger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
