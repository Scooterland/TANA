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
        public async Task EnsureAdminExistsAsync()
        {
            // Fetch all users
            var alleBrugere = await _repo.GetAllAsync();

            // Look for a user with exactly this email
            bool adminExists = alleBrugere
                .Any(u => u.Email.Equals("admin@admin.dk", StringComparison.OrdinalIgnoreCase));

            if (!adminExists)
            {
                // If not found, create it now
                var admin = new Bruger
                {
                    Navn = "Admin",
                    Email = "admin@admin.dk",
                    Rolle = "Admin"
                    // PasswordHash will be set by AddAsync(...)
                };

                // Password “1234” (plaintext) will be BCrypt-hashed inside AddAsync(...)
                await AddAsync(admin, "1234");
            }
        }
    }
}
