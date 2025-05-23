using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
	public interface IRejseService
	{
		public Task<IEnumerable<Rejse>> GetAllAsync();
		public Task<Rejse?> GetByIdAsync(int id);
		public Task AddAsync(Rejse rejse);
		public Task UpdateAsync(Rejse rejse);
		public Task DeleteAsync(int id);
	}
}