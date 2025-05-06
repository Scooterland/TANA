using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;
using TANA.Application.Interfaces;
using TANA.Domain.Entities;
using TANA.Domain.Repositories;

namespace TANA.Application.Services
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
                Pris = t.Pris,
                Dage = t.Dage
            }).ToList();
        }

        public async Task<TurDto?> GetTurByIdAsync(Guid id)
        {
            var allTure = await _turRepository.GetAllAsync();
            var tur = allTure.FirstOrDefault(t => t.Id == id.GetHashCode()); // Guid -> int conversion
            if (tur == null)
                return null;

            return new TurDto
            {
                Id = tur.Id,
                Navn = tur.Navn,
                Pris = tur.Pris,
                Dage = tur.Dage
            };
        }

        public async Task CreateTurAsync(string title, string description)
        {
            // Hvis description skal bruges, bør det tilføjes til Tur entiteten
            var tur = new Tur
            {
                Navn = title,
                Pris = 0,   // Dummy værdi – du kan tilpasse
                Dage = 1    // Dummy værdi
            };

            await _turRepository.AddAsync(tur);
        }
    }
}
