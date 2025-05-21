using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Interface;
using TANA.Domain.Entities;

namespace TANA.Application.Services
{
    public class KundeService : IKundeService
    {
        private readonly IKundeRepository _repo;
        public KundeService(IKundeRepository repo) => _repo = repo;

        public Task<IEnumerable<Kunde>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Kunde?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Kunde kunde) => _repo.AddAsync(kunde);
        public Task UpdateAsync(Kunde kunde) => _repo.UpdateAsync(kunde);
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}
