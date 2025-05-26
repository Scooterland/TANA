using TANA.Application.DTOs;
using TANA.Domain.Entities;
using TANA.Application.Interface;

namespace TANA.Infrastructure.Services
{
    public class TravelPlanService : ITravelPlanService
    {
        private readonly ITurRepository _turRepo;
        private readonly IRejseRepository _rejseRepo;

        public TravelPlanService(ITurRepository turRepo, IRejseRepository rejseRepo)
        {
            _turRepo = turRepo;
            _rejseRepo = rejseRepo;
        }

        public async Task<int> CreateTravelPlanAsync(string navn, List<int> turIds, int kundeId, string description, double pris, int dage)
        {
            // Hent de relevante ture
            var ture = (await _turRepo.GetByIdsAsync(turIds)).ToList();

            if (ture == null || !ture.Any())
                throw new Exception("Ingen ture fundet for de angivne IDs");

            // Opret rejse
            var rejse = new Rejse
            {
                Navn = navn,
                StartsDato = DateOnly.FromDateTime(DateTime.Now),
                SlutsDato = DateOnly.FromDateTime(DateTime.Now.AddDays(dage)),
                Dage = dage,
                Pris = pris,
                Kommentar = description,
                KundeId = kundeId
            };

            // Opret relationen mellem tur og rejse
            foreach (var tur in ture)
            {
                var rejseTur = new RejseTur
                {
                    Tur = tur,
                    Pris = tur.Pris,
                    Dage = tur.Dage,
                    TurId = tur.Id,
                    Rejse = rejse
                };

                rejse.RejseTurer.Add(rejseTur);
            }

            // Gem rejseplanen
            await _rejseRepo.AddAsync(rejse);

            return rejse.Id;
        }

        public async Task<List<RejsePlanDto>> GetAllRejseplanerAsync()
        {
            var rejser = await _rejseRepo.GetAllAsync();

            return rejser.Select(rejse => new RejsePlanDto
            {
                Id = rejse.Id,
                Navn = rejse.Navn,
                Pris = rejse.Pris,
                Dage = rejse.Dage,
                Ture = rejse.RejseTurer.Select(rt => new TurDto
                {
                    Id = rt.Tur.Id,
                    Navn = rt.Tur.Navn,
                }).ToList()
            }).ToList();
        }

        public async Task DeleteTravelPlanAsync(int id)
        {
            var rejse = await _rejseRepo.GetByIdAsync(id);

            if (rejse == null)
                throw new Exception($"Rejseplan med ID {id} blev ikke fundet.");

			await _rejseRepo.DeleteAsync(rejse.Id);
        }
    }
}
