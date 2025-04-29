using DinkToPdf.Contracts;
using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Interface;

namespace TANA.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService()
        {
            _converter = new BasicConverter(new PdfTools());
        }

        public async Task<byte[]> GeneratePdfAsync(string content)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait
            },
                Objects = {
                new ObjectSettings() {
                    HtmlContent = content
                }
            }
            };

            return await Task.FromResult(_converter.Convert(doc));
        }
    }
}
