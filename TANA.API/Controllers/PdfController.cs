using Microsoft.AspNetCore.Mvc;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuestPDF.Fluent;
using TANA.Application.DTOs;
using TANA.Infrastructure.Services;

namespace TANA.API.Controllers
{
    [ApiController]
    [Route("api/pdf/rejseplan")]
    [IgnoreAntiforgeryToken]
    public class PdfController : Controller
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
            try 
            { 
            var document = new RejseplanDocument(request);  // Opret en ny dokumentklasse for Rejseplan
            var pdfBytes = document.GeneratePdf();
            _lastGeneratedPdf = pdfBytes;  // Behold hvis du stadig vil kunne se via /view
            return File(pdfBytes, "application/pdf", "rejseplan.pdf");
        
            }
            catch (Exception ex)
        {
        // Log evt. også til fil!
        return BadRequest($"PDF-fejl: {ex.Message} {ex.StackTrace}");
        }
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