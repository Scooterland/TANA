using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface IKundeRepository
    {
        Task<IEnumerable<Kunde>> GetAllAsync();
        Task<Kunde?> GetByIdAsync(Guid id);
        Task AddAsync(Kunde kunde);
        Task UpdateAsync(Kunde kunde);
        Task DeleteAsync(Guid id);
    }
}
