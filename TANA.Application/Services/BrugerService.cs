using TANA.Domain.Entities;
using TANA.Application.Interface;

namespace TANA.Application.Services
{
    public class BrugerService : IBrugerService
    {
        private readonly IBrugerRepository _repo;
        public BrugerService(IBrugerRepository repo) => _repo = repo;

        public Task<IEnumerable<Bruger>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Bruger?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public async Task AddAsync(Bruger bruger, string plainPassword)
        {
            bruger.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            await _repo.AddAsync(bruger);
        }
        public Task UpdateAsync(Bruger bruger) => _repo.UpdateAsync(bruger);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
