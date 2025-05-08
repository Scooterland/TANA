using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;
using TANA.Application.Interfaces;
using TANA.Domain.Entities;
using TANA.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateTravelPlanAsync(string navn, List<int> turIds, int kundeId)
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
                SlutsDato = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Dage = 5,
                Pris = ture.Sum(t => t.Pris),
                Kommentar = "En spændende rejseplan",
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
                Ture = rejse.RejseTurer.Select(rt => new TurDto
                {
                    Id = rt.Tur.Id,
                    Navn = rt.Tur.Navn,
                    Pris = rt.Pris,
                    Dage = rt.Dage
                }).ToList()
            }).ToList();
        }
    }
}
