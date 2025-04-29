using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Interface;

namespace TANA.Application.Services
{
    public class RejseplanService
    {
        private readonly IPdfService _pdfService;
        private readonly IEmailService _emailService;

        public RejseplanService(IPdfService pdfService, IEmailService emailService)
        {
            _pdfService = pdfService;
            _emailService = emailService;
        }

        public async Task SendRejseplanEmailAsync(string toEmail, string rejseplanContent)
        {
            // Generer PDF af rejseplanen
            var pdfBytes = await _pdfService.GeneratePdfAsync(rejseplanContent);

            // Send PDF som vedhæftet fil
            await _emailService.SendEmailAsync(toEmail, "Din rejseplan", "Her er din rejseplan.", pdfBytes);
        }
    }
}
