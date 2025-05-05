using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;
using TANA.Domain.Repositories;
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

        public async Task<IEnumerable<Tur>> GetByIdsAsync(IEnumerable<int> ids)
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
    }
}
