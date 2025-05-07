using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TANA.Domain.Entities;
using TANA.Domain.Interface;
using TANA.Persistence.Data;

namespace TANA.Persistence.Repositories
{
    public class TurRepository : ITurRepository
    {
        private readonly AppDbContext _context;
        public TurRepository(AppDbContext ctx) => _context = ctx;

        public async Task<IEnumerable<Tur>> GetAllAsync() =>
            await _context.Turer.AsNoTracking().ToListAsync();

        public async Task<Tur?> GetByIdAsync(int id) =>
            await _context.Turer.FindAsync(id);

        public async Task AddAsync(Tur tur)
        {
            _context.Turer.Add(tur);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tur tur)
        {
            _context.Turer.Update(tur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Turer.FindAsync(id);
            if (entity is null) return;
            _context.Turer.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}