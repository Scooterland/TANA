using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Application.Interface
{
    public interface IBrugerRepository
    {
        Task<IEnumerable<Bruger>> GetAllAsync();
        Task<Bruger?> GetByIdAsync(int id);
        Task AddAsync(Bruger bruger);
        Task UpdateAsync(Bruger bruger);
        Task DeleteAsync(int id);
    }
}
