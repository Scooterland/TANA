using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface ITurRepository
    {
        Task<List<Tur>> GetAllAsync();
        Task<List<Tur>> GetByIdsAsync(IEnumerable<int> ids);
        Task AddAsync(Tur tur);
        Task DeleteAsync(int id);
    }
}
