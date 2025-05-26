using Microsoft.EntityFrameworkCore;
using TANA.Domain.Entities;
using TANA.Persistence.Data;
using TANA.Application.Interface;


namespace TANA.Persistence.Repositories
{
    public class RejseRepository : IRejseRepository
    {
        private readonly AppDbContext db;

		public RejseRepository(AppDbContext context) => db = context;

        public async Task<IEnumerable<Rejse>> GetAllAsync()
        {
            return await db.Rejser.Include(r => r.RejseTurer).ThenInclude(rt => rt.Tur).ToListAsync();
        }

        public async Task<Rejse?> GetByIdAsync(int id)
        {
            return await db.Rejser.Include(r => r.RejseTurer).ThenInclude(rt => rt.Tur).FirstOrDefaultAsync(r => r.Id == id);
        }


        public async Task AddAsync(Rejse rejse)
        {
            db.Rejser.Add(rejse);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Rejse rejse)
        {
            db.Rejser.Update(rejse);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await db.Rejser.FindAsync(id);
            if (entity is null) return;
            db.Rejser.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
