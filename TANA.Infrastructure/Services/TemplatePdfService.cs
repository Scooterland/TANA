using TANA.Domain.Entities;
using QuestPDF.Fluent;

namespace TANA.Infrastructure.Services
{
    public class TemplatePdfService
    {
        public byte[] Generate(TemplateEntity template)
        {
            var doc = new TemplateDocument(template);
            return doc.GeneratePdf();
        }
    }
}
