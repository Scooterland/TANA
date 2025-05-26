using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Application.Interface
{
    public interface ITurRepository
    {
        Task<List<Tur>> GetAllAsync();
        Task<List<Tur>> GetByIdsAsync(IEnumerable<int> ids);
        Task AddAsync(Tur tur);
        Task DeleteAsync(int id);
    }
}
