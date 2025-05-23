using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface IBrugerRepository
    {
        Task<IEnumerable<Bruger>> GetAllAsync();
        Task<Bruger?> GetByIdAsync(int id);
        Task AddAsync(Bruger bruger);
        Task UpdateAsync(Bruger bruger);
        Task DeleteAsync(int id);
    }
}
