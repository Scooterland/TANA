using DinkToPdf.Contracts;
using DinkToPdf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TANA.Domain.Entities;
using System;

namespace TANA.Infrastructure.Services
{
    public class PdfGenerationService
    {
        private readonly IConverter _converter;

        public PdfGenerationService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdf(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
        },
                Objects = {
            new ObjectSettings()
            {
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" }
            }
        }
            };

            try
            {
                return _converter.Convert(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating PDF: {ex.Message}");
                return Array.Empty<byte>();
            }
        }


        public string GenerateHtmlFromTemplate(
     string templateName,
     List<TemplateItem> items,
     int templateId,
     DateTime createdDate,
     DateTime lastModifiedDate,
     string primaryColor,
     string headerBgColor,
     string footerBgColor,
     string fontFamily,
     string mainImageUrl)
        {
            var headerItem = items.FirstOrDefault(i => i.Content == "Header");
            string headerTitle = headerItem?.Title ?? templateName;
            string headerDate = headerItem?.Activity ?? string.Empty;
            string headerImageUrl = headerItem?.Note ?? string.Empty;

            const string logoUrl = "https://tanzania-eksperten.dk/wp-content/uploads/2021/08/Logo_Logo-lang-dark-1.svg";
            const string footerLogo = "https://tanzania-eksperten.dk/wp-content/uploads/2024/10/logo-3280.png.png";

            var sb = new StringBuilder();
            sb.AppendLine($@"
<html>
<head>
    <meta charset='utf-8' />
    <style>
        body {{ font-family: '{fontFamily}', sans-serif; }}
        .page-header, .page-footer {{
            background-color: {headerBgColor};
            color: #fff;
            padding: 10px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }}
        .day-section h3 {{
            color: {primaryColor};
        }}
        .page-body {{
            padding: 20px;
        }}
    </style>
</head>
<body>
    <div class='page-header'>
        <img src='{logoUrl}' style='max-height: 50px;' />
        <h2>{headerTitle}</h2>
        {(string.IsNullOrWhiteSpace(headerImageUrl) ? "" : $"<img src='{headerImageUrl}' style='max-height:50px;' />")}
    </div>
    <div class='page-body'>");

            if (!string.IsNullOrWhiteSpace(mainImageUrl))
            {
                sb.AppendLine($@"
        <div style='text-align: center; margin-bottom: 15px;'>
            <img src='{mainImageUrl}' style='max-width: 100%; max-height: 350px; border-radius: 6px; border: 1px solid #ddd;' />
        </div>");
            }

            var summary = items.FirstOrDefault(i => i.Content == "Summary")?.Note;
            if (!string.IsNullOrWhiteSpace(summary))
                sb.AppendLine($"<p>{summary}</p>");

            var days = items.Where(i => i.Content == "Day Sections").OrderBy(i => i.Order).ToList();
            int d = 1;
            foreach (var day in days)
            {
                sb.AppendLine($@"
        <div class='day-section'>
            <h3>Dag {d}: {day.Title}</h3>
            <p><strong>Aktivitet:</strong> {day.Activity}</p>
            <p><strong>Måltider inkluderet:</strong> {day.Meals}</p>
            <p><strong>Overnatning:</strong> {day.Accommodation}</p>
            <p><strong>Notat:</strong> {day.Note}</p>
        </div>");
                d++;
            }

            sb.AppendLine($@"
    </div>
    <div class='page-footer'>
        <img src='{footerLogo}' style='max-height: 50px;' />
        <div>
            Tanzania Eksperten Aps<br/>CVR. Nr.: 41239425
        </div>
        <div>
            Mobile: +45 42 73 10 45<br/>
            Email: kontakt@tanzania-eksperten.dk<br/>
            <a href='https://tanzania-eksperten.dk'>www.tanzania-eksperten.dk</a>
        </div>
    </div>
</body>
</html>");

            return sb.ToString();
        }



    }
}
