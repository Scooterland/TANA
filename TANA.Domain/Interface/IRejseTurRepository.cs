using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface IRejseturRepository
    {
        Task<IEnumerable<RejseTur>> GetAllAsync();
        Task<RejseTur?> GetByIdAsync(int id);
        Task AddAsync(RejseTur rejsetur);
        Task UpdateAsync(RejseTur rejsetur);
        Task DeleteAsync(int id);
    }
}
