using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;

namespace TANA.Application.Interfaces
{
    public interface ITurService
    {
        Task<List<TurDto>> GetAllTurAsync();
        Task<TurDto?> GetTurByIdAsync(int id);
        Task CreateTurAsync(string title, string description, int pris, int dage);
    }
}
