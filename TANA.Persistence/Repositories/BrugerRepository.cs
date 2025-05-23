using TANA.Persistence.Data;
using TANA.Domain.Interface;
using TANA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TANA.Persistence.Repositories
{
    public class BrugerRepository : IBrugerRepository
    {
        private readonly AppDbContext db;
        public BrugerRepository(AppDbContext context) => db = context;

        public async Task<IEnumerable<Bruger>> GetAllAsync() => await db.Brugere.ToListAsync();
        public async Task<Bruger?> GetByIdAsync(int id) => await db.Brugere.FindAsync(id);
        public async Task AddAsync(Bruger bruger) { db.Brugere.Add(bruger); await db.SaveChangesAsync(); }
        public async Task UpdateAsync(Bruger bruger) { db.Brugere.Update(bruger); await db.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var bruger = await db.Brugere.FindAsync(id);
            if (bruger is not null)
            {
                db.Brugere.Remove(bruger);
                await db.SaveChangesAsync();
            }
        }
    }
}
