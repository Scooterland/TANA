using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;

namespace TANA.Application.Interfaces
{
    public interface ITripService
    {
        Task<List<TripDto>> GetAllTripsAsync();
        Task<TripDto?> GetTripByIdAsync(Guid id);
        Task CreateTripAsync(string title, string description);
    }
}
