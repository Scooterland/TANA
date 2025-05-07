using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface ITurRepository
    {
        Task<IEnumerable<Tur>> GetAllAsync();
        Task<Tur?> GetByIdAsync(int id);
        Task AddAsync(Tur tur);
        Task UpdateAsync(Tur tur);
        Task DeleteAsync(int id);
    }
}