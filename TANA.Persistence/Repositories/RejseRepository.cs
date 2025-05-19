using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;
using TANA.Domain.Repositories;
using TANA.Persistence.Data;
using TANA.Domain.Interface;


namespace TANA.Persistence.Repositories
{
    public class RejseRepository : IRejseRepository
    {
        private readonly AppDbContext _context;

        public RejseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rejse>> GetAllAsync()
        {
            return await _context.Rejser.Include(r => r.RejseTurer).ThenInclude(rt => rt.Tur).ToListAsync();
        }

        public async Task<Rejse?> GetByIdAsync(int id)
        {
            return await _context.Rejser.Include(r => r.RejseTurer).ThenInclude(rt => rt.Tur).FirstOrDefaultAsync(r => r.Id == id);
        }


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
