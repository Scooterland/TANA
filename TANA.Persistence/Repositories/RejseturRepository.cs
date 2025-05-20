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
    public class RejseturRepository : IRejseturRepository
    {
        private readonly AppDbContext _context;
        public RejseturRepository(AppDbContext ctx) => _context = ctx;

        public async Task<IEnumerable<RejseTur>> GetAllAsync() =>
            await _context.RejseTurer.AsNoTracking().ToListAsync();

        public async Task<RejseTur?> GetByIdAsync(int id) =>
            await _context.RejseTurer.FindAsync(id);

        public async Task AddAsync(RejseTur rejsetur)
        {
            _context.RejseTurer.Add(rejsetur);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RejseTur rejsetur)
        {
            _context.RejseTurer.Update(rejsetur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RejseTurer.FindAsync(id);
            if (entity is null) return;
            _context.RejseTurer.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}