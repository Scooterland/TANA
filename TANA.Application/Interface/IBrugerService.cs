using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface IBrugerService
    {
		public Task<IEnumerable<Bruger>> GetAllAsync();
		public Task<Bruger?> GetByIdAsync(int id);
		public Task AddAsync(Bruger bruger);
		public Task UpdateAsync(Bruger bruger);
		public Task DeleteAsync(int id);
	}
}
