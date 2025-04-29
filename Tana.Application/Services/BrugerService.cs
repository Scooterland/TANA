using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Interface;
using TANA.Domain.Entities;

namespace TANA.Application.Services
{
    public class BrugerService
    {
        private readonly IBrugerRepository _repo;
        public BrugerService(IBrugerRepository repo) => _repo = repo;

        public Task<IEnumerable<Bruger>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Bruger?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Bruger bruger) => _repo.AddAsync(bruger);
        public Task UpdateAsync(Bruger bruger) => _repo.UpdateAsync(bruger);
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}
