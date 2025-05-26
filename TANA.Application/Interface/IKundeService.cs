using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Application.Interface
{
	public interface IKundeService
	{
		public Task<IEnumerable<Kunde>> GetAllAsync();
		public Task<Kunde?> GetByIdAsync(int id);
		public Task AddAsync(Kunde kunde);
		public Task UpdateAsync(Kunde kunde);
		public Task DeleteAsync(int id);
	}
}