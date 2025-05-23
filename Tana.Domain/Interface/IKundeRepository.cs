using TANA.Domain.Entities;

namespace TANA.Domain.Interface
{
    public interface IKundeRepository
    {
        Task<IEnumerable<Kunde>> GetAllAsync();
        Task<Kunde?> GetByIdAsync(Guid id);
        Task AddAsync(Kunde kunde);
        Task UpdateAsync(Kunde kunde);
        Task DeleteAsync(int id);
    }
}
