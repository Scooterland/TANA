using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;
using TANA.Domain.Interface;

namespace TANA.Application.Services
{
    public class RejseturService
    {
        private readonly IRejseturRepository _rejseturRepository;

        public RejseturService(IRejseturRepository rejseturRepository)
        {
            _rejseturRepository = rejseturRepository;
        }

        public Task<IEnumerable<RejseTur>> GetAllAsync() => _rejseturRepository.GetAllAsync();
        public Task<RejseTur?> GetByIdAsync(int id) => _rejseturRepository.GetByIdAsync(id);
        public Task AddAsync(RejseTur rejsetur) => _rejseturRepository.AddAsync(rejsetur);
        public Task UpdateAsync(RejseTur rejsetur) => _rejseturRepository.UpdateAsync(rejsetur);
        public Task DeleteAsync(int id) => _rejseturRepository.DeleteAsync(id);
    }
}