using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TANA.Domain.Entities;

namespace TANA.Infrastructure.Services
{
    public class TemplateDocument : IDocument
    {
        private readonly TemplateEntity _template;

        public TemplateDocument(TemplateEntity template)
        {
            _template = template;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);

                // ============ HEADER ============
                page.Header().Row(row =>
                {
                    if (!string.IsNullOrEmpty(_template.ImageUrl) && _template.ImageUrl.StartsWith("data:image"))
                    {
                        row.ConstantItem(60).Image(_template.ImageUrl);
                    }
                    else
                    {
                        row.ConstantItem(60); 
                    }

                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text(_template.TemplateName)
                            .FontSize(22)
                            .Bold()
                            .FontColor(_template.PrimaryColor ?? Colors.Blue.Medium);

                        if (!string.IsNullOrWhiteSpace(_template.Summary))
                        {
                            column.Item().Text(_template.Summary)
                                .FontSize(12)
                                .Italic()
                                .FontColor(Colors.Grey.Medium);
                        }
                    });

                    row.ConstantItem(100).AlignRight().Text(_template.CreatedDate.ToString("yyyy-MM-dd"));
                });

                // ============ BODY ============
                page.Content().PaddingVertical(10).Column(stack =>
                {
                    var days = _template.Items.Where(i => i.Content == "Day Sections").ToList();
                    if (days.Any())
                    {
                        stack.Item().PaddingBottom(10).Text("Day Sections").FontSize(16).Bold();

                        stack.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1); // Day
                                columns.RelativeColumn(2); // Title
                                columns.RelativeColumn(3); // Activity
                                columns.RelativeColumn(2); // Meals
                                columns.RelativeColumn(2); // Accommodation
                                columns.RelativeColumn(3); // Note
                            });

                            // Header row
                            table.Header(header =>
                            {
                                header.Cell().Background(_template.PrimaryColor ?? Colors.Grey.Lighten2).Text("Day").Bold();
                                header.Cell().Background(_template.PrimaryColor ?? Colors.Grey.Lighten2).Text("Title").Bold();
                                header.Cell().Background(_template.PrimaryColor ?? Colors.Grey.Lighten2).Text("Activity").Bold();
                                header.Cell().Background(_template.PrimaryColor ?? Colors.Grey.Lighten2).Text("Meals").Bold();
                                header.Cell().Background(_template.PrimaryColor ?? Colors.Grey.Lighten2).Text("Accommodation").Bold();
                                header.Cell().Background(_template.PrimaryColor ?? Colors.Grey.Lighten2).Text("Note").Bold();
                            });

                            int dayNum = 1;
                            foreach (var day in days)
                            {
                                table.Cell().Text($"Day {dayNum++}");
                                table.Cell().Text(day.Title ?? "");
                                table.Cell().Text(day.Activity ?? "");
                                table.Cell().Text(day.Meals ?? "");
                                table.Cell().Text(day.Accommodation ?? "");
                                table.Cell().Text(day.Note ?? "");
                            }
                        });
                    }

                    var summaryItem = _template.Items.FirstOrDefault(i => i.Content == "Summary");
                    if (summaryItem != null && !string.IsNullOrWhiteSpace(summaryItem.Note))
                    {
                        stack.Item().PaddingTop(10).Text("Summary:").Bold();
                        stack.Item().Text(summaryItem.Note);
                    }

                    // header
                    var headerItem = _template.Items.FirstOrDefault(i => i.Content == "Header");
                    if (headerItem != null)
                    {
                        stack.Item().PaddingTop(10).Text("Header:").Bold();
                        stack.Item().Text(headerItem.Title ?? "");
                    }
                });

                // ============ FOOTER ============
                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
        }
    }
}
