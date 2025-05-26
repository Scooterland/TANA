using TANA.Domain.Entities;
using TANA.Domain.Interface;

namespace TANA.Application.Services
{
        public class RejseService : IRejseService
        {
            private readonly IRejseRepository _repo;
            public RejseService(IRejseRepository repo) => _repo = repo;

            public async Task<IEnumerable<Rejse>> GetAllAsync()
            {
                try
                {
                    return await _repo.GetAllAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl ved hentning af rejser: {ex.Message}");
                    return Enumerable.Empty<Rejse>();
                }
            }

            public async Task<Rejse?> GetByIdAsync(int id)
            {
                try
                {
                    return await _repo.GetByIdAsync(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl ved hentning af rejse med id {id}: {ex.Message}");
                    return null;
                }
            }

            public async Task AddAsync(Rejse rejse)
            {
                try
                {
                    await _repo.AddAsync(rejse);
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
