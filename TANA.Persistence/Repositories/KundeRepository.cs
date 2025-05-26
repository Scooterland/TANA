using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TANA.Domain.Entities;
using TANA.Domain.Interface;
using TANA.Persistence.Data;

namespace TANA.Persistence.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        private readonly AppDbContext _context;
        public KundeRepository(AppDbContext ctx) => _context = ctx;

        public async Task<IEnumerable<Kunde>> GetAllAsync() =>
            await _context.Kunder.AsNoTracking().ToListAsync();

        public async Task<Kunde?> GetByIdAsync(Guid id) =>
            await _context.Kunder.FindAsync(id);

        public async Task AddAsync(Kunde kunde)
        {
            _context.Kunder.Add(kunde);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kunde kunde)
        {
            _context.Kunder.Update(kunde);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Kunder.FindAsync(id);
            if (entity is null) return;
            _context.Kunder.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
