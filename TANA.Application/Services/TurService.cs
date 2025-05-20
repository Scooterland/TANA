using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;
using TANA.Domain.Interface;

namespace TANA.Application.Services
{
    public class TurService
    {
        private readonly ITurRepository _turRepository;

        public TurService(ITurRepository turRepository)
        {
            _turRepository = turRepository;
        }

        public Task<IEnumerable<Tur>> GetAllAsync() => _turRepository.GetAllAsync();
        public Task<Tur?> GetByIdAsync(int id) => _turRepository.GetByIdAsync(id);
        public Task AddAsync(Tur tur) => _turRepository.AddAsync(tur);
        public Task UpdateAsync(Tur tur) => _turRepository.UpdateAsync(tur);
        public Task DeleteAsync(int id) => _turRepository.DeleteAsync(id);
    }
}