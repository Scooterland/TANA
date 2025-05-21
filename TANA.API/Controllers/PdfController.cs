using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuestPDF.Fluent;
using Microsoft.AspNetCore.Mvc;
using TANA.Application.DTOs;
using TANA.Infrastructure.Services;

namespace TANA.API.Controllers
{
    [ApiController]
    [Route("api/pdf/rejseplan")]
    public class PdfController : ControllerBase
    {
        private static byte[] _lastGeneratedPdf;

        [HttpPost]
        public IActionResult Generate([FromBody] RejseplanModel request)
        {
            var model = new RejseplanModel
            {
                Navn = request.Navn,
                Email = request.Email,
                Destination = request.Destination,
                Afrejse = request.Afrejse,
                Hjemrejse = request.Hjemrejse,
                Flyselskab = request.Flyselskab
            };

            var document = new RejseplanDocument(model);  // Opret en ny dokumentklasse for Rejseplan
            _lastGeneratedPdf = document.GeneratePdf();
            return Ok();
        }

        [HttpGet("view")]
        public IActionResult ViewPdf()
        {
            if (_lastGeneratedPdf == null)
                return NotFound();

            return File(_lastGeneratedPdf, "application/pdf", "rejseplan.pdf");
        }
    }
}
