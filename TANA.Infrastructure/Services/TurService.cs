using TANA.Application.DTOs;
using TANA.Application.Interface;
using TANA.Domain.Entities;

namespace TANA.Infrastructure.Services
{
    public class TurService : ITurService
    {
        private readonly ITurRepository _turRepository;

        public TurService(ITurRepository turRepository)
        {
            _turRepository = turRepository;
        }

        public async Task<List<TurDto>> GetAllTurAsync()
        {
            var ture = await _turRepository.GetAllAsync();

            return ture.Select(t => new TurDto
            {
                Id = t.Id,
                Navn = t.Navn,
                Description = t.Description,
                Pris = t.Pris,
                Dage = t.Dage
            }).ToList();
        }

        public async Task<List<TurDto>> GetTurByIdsAsync(IEnumerable<int> ids)
        {
            var ture = await _turRepository.GetByIdsAsync(ids);

            return ture.Select(t => new TurDto
            {
                Id = t.Id,
                Navn = t.Navn,
                Description = t.Description,
                Pris = t.Pris,
                Dage = t.Dage
            }).ToList();
        }

        public async Task CreateTurAsync(string navn, string description, int pris, int dage)
        {
            var tur = new Tur
            {
                Navn = navn,
                Description = description,
                Pris = pris,
                Dage = dage
            };

            await _turRepository.AddAsync(tur); // <- denne skal kaldes!
        }

        public async Task DeleteTurAsync(int id)
        {
            await _turRepository.DeleteAsync(id);
        }
    }
}
