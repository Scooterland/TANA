using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;
using TANA.Domain.Entities;
using TANA.Persistence.Data;

namespace TANA.Persistence.Repositories
{
    public class TurRepository : ITurRepository
    {
        private readonly AppDbContext _context;

        public TurRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tur>> GetAllAsync()
        {
            return await _context.Turer.ToListAsync();
        }

        public async Task<List<Tur>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Turer
                .Where(t => ids.Contains(t.Id))
                .ToListAsync();
        }

        public async Task AddAsync(Tur tur)
        {
            _context.Turer.Add(tur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tur = await _context.Turer.FindAsync(id);
            if (tur != null)
            {
                _context.Turer.Remove(tur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
