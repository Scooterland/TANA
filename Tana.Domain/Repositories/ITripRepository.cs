using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Repositories
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAllAsync();
        Task<IEnumerable<Trip>> GetByIdAsync(IEnumerable<Guid> ids);
        Task AddAsync(Trip trip);
    }
}
