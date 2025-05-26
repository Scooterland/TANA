using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;

namespace TANA.Application.Interface
{
	public interface ITravelPlanService
	{
		Task<int> CreateTravelPlanAsync(string navn, List<int> turIds, int kundeId, string description, double pris, int dage);
		Task<List<RejsePlanDto>> GetAllRejseplanerAsync();
		Task DeleteTravelPlanAsync(int id);
	}
}