using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Repositories
{
    public interface IRejseRepository
    {
        Task<List<Rejse>> GetAllAsync();
        Task<Rejse?> GetByIdAsync(int id);
        Task AddAsync(Rejse rejse);
        Task DeleteAsync(Rejse rejse);
    }
}
