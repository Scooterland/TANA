using TANA.Application.Interface;
using TANA.Domain.Entities;

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
}
