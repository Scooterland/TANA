using System.Collections.Generic;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Application.Interface
{
    public interface IRejseRepository
    {
        Task<IEnumerable<Rejse>> GetAllAsync();
        Task<Rejse?> GetByIdAsync(int id);
        Task AddAsync(Rejse rejse);
        Task UpdateAsync(Rejse rejse);
        Task DeleteAsync(int id);
    }
}
