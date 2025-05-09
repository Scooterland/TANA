using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.Interfaces;
using TANA.Application.DTOs;

namespace TANA.Application.Interfaces
{
    public interface ITravelPlanService
    {
        Task<int> CreateTravelPlanAsync(string navn, List<int> turIds, int kundeId);
        Task<List<RejsePlanDto>> GetAllRejseplanerAsync();
    }
}
