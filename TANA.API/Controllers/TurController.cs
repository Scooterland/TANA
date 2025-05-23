using Microsoft.AspNetCore.Mvc;
using TANA.Application.DTOs;
using TANA.Application.Interface;

namespace TANA.API.Web.Controllers
{
    [ApiController]
    [Route("api/tur")]
    public class TurController : ControllerBase
    {
        private readonly ITurService _turService;

        public TurController(ITurService turService)
        {
            _turService = turService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ture = await _turService.GetAllTurAsync();
            return Ok(ture);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TurDto dto)
        {
            await _turService.CreateTurAsync(dto.Navn, dto.Description, (int)dto.Pris, dto.Dage);
            return Ok();
        }

        [HttpPost("byids")]
        public async Task<IActionResult> GetByIds([FromBody] List<int> ids)
        {
            var result = await _turService.GetTurByIdsAsync(ids);
            return Ok(result);
        }
    }
}
