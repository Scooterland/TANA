using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TANA.Domain.Entities;
using TANA.Domain.Interface;
using TANA.Persistence.Data;

namespace TANA.Persistence.Repositories
{
    public class RejseRepository : IRejseRepository
    {
        private readonly AppDbContext _context;
        public RejseRepository(AppDbContext ctx) => _context = ctx;

        public async Task<IEnumerable<Rejse>> GetAllAsync() =>
            await _context.Rejser.AsNoTracking().ToListAsync();

        public async Task<Rejse?> GetByIdAsync(int id) =>
            await _context.Rejser.FindAsync(id);

        public async Task AddAsync(Rejse rejse)
        {
            _context.Rejser.Add(rejse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rejse rejse)
        {
            _context.Rejser.Update(rejse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Rejser.FindAsync(id);
            if (entity is null) return;
            _context.Rejser.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
