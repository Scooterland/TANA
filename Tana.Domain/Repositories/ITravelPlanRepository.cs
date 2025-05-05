using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Repositories
{
    public interface ITravelPlanRepository
    {
        Task<List<TravelPlan>> GetAllAsync();
        Task<TravelPlan?> GetByIdAsync(Guid id);
        Task AddAsync(TravelPlan plan);
    }
}
