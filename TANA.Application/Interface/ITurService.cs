using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;

namespace TANA.Application.Interface
{
	public interface ITurService
	{
		Task<List<TurDto>> GetAllTurAsync();
		Task<List<TurDto>> GetTurByIdsAsync(IEnumerable<int> ids);
		Task CreateTurAsync(string navn, string description, int pris, int dage);
		Task DeleteTurAsync(int id);
	}
}