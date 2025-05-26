using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;
using TANA.Domain.Entities;
using TANA.Persistence.Data;

namespace TANA.Persistence.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        private readonly AppDbContext db;
        public KundeRepository(AppDbContext context) => db = context;

        public async Task<IEnumerable<Kunde>> GetAllAsync() =>
            await db.Kunder.AsNoTracking().ToListAsync();

        public async Task<Kunde?> GetByIdAsync(int id) =>
            await db.Kunder.FindAsync(id);

        public async Task AddAsync(Kunde kunde)
        {
            db.Kunder.Add(kunde);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kunde kunde)
        {
            var existingEntity = await db.Kunder.FindAsync(kunde.Id);
            if (existingEntity != null)
            {
                db.Entry(existingEntity).CurrentValues.SetValues(kunde);
            }
            else
            {
                db.Kunder.Attach(kunde);
                db.Entry(kunde).State = EntityState.Modified;
            }
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await db.Kunder.FindAsync(id);
            if (entity is null) return;
            db.Kunder.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
