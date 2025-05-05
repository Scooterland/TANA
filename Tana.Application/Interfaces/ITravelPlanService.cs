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
        Task<List<TravelPlanDto>> GetAllTravelPlansAsync();
        Task<TravelPlanDto?> GetTravelPlanByIdAsync(Guid id);
        Task<Guid> CreateTravelPlanAsync(string title, List<Guid> tripIds);
        Task CustomizeTripInPlanAsync(Guid travelPlanId, Guid tripId, string newTitle, string newDescription);
    }
}
