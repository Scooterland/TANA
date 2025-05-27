using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;
using TANA.Domain.Entities;
using TANA.Persistence.Data;

namespace TANA.Persistence.Repositories
{
	public class BrugerRepository : IBrugerRepository
	{
		private readonly AppDbContext db;
		public BrugerRepository(AppDbContext context) => db = context;

        public async Task<IEnumerable<Bruger>> GetAllAsync() => await db.Brugere.ToListAsync();
        public async Task<Bruger?> GetByIdAsync(int id) => await db.Brugere.FindAsync(id);
        public async Task AddAsync(Bruger bruger)
        {
            db.Brugere.Add(bruger);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bruger bruger)
        {
            var tracked = await db.Brugere.FindAsync(bruger.Id);
            if (tracked != null)
            {
                db.Entry(tracked).CurrentValues.SetValues(bruger);
            }
            else
            {
                db.Brugere.Attach(bruger);
                db.Entry(bruger).State = EntityState.Modified;
            }
            await db.SaveChangesAsync();
        }

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