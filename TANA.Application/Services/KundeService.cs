using TANA.Domain.Entities;
using TANA.Application.Interface;

namespace TANA.Application.Services
{
    public class KundeService : IKundeService
    {
        private readonly IKundeRepository db;
        public KundeService(IKundeRepository repo) => db = repo;

        public Task<IEnumerable<Kunde>> GetAllAsync() => db.GetAllAsync();
        public Task<Kunde?> GetByIdAsync(int id) => db.GetByIdAsync(id);
        public Task AddAsync(Kunde kunde) => db.AddAsync(kunde);
        public Task UpdateAsync(Kunde kunde) => db.UpdateAsync(kunde);
        public Task DeleteAsync(int id) => db.DeleteAsync(id);
    }
}
