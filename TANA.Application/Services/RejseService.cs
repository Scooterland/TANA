using TANA.Domain.Entities;
using TANA.Domain.Interface;

namespace TANA.Application.Services
{
        public class RejseService : IRejseService
        {
            private readonly IRejseRepository _repo;
            public RejseService(IRejseRepository repo) => _repo = repo;

        public Task<IEnumerable<Rejse>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Rejse?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Rejse rejse) => _repo.AddAsync(rejse);
        public Task UpdateAsync(Rejse rejse) => _repo.UpdateAsync(rejse);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl ved tilføjelse af rejse: {ex.Message}");
                    throw;
                }
            }

            public async Task UpdateAsync(Rejse rejse)
            {
                try
                {
                    await _repo.UpdateAsync(rejse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl ved opdatering af rejse: {ex.Message}");
                    throw;
                }
            }

            public async Task DeleteAsync(int id)
            {
                try
                {
                    await _repo.DeleteAsync(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl ved sletning af rejse: {ex.Message}");
                    throw;
                }
            }
        }

    
}
