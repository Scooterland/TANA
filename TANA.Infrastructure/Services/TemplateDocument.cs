using QuestPDF.Fluent;
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

                page.Header().Text(_template.TemplateName).FontSize(24).Bold();

                page.Content().Element(content =>
                {
                    content.Column(col =>
                    {
                        foreach (var item in _template.Items.OrderBy(i => i.Order))
                        {
                            col.Item().Text($"[{item.Content}] {item.Title ?? ""} - {item.Activity ?? ""} - {item.Note ?? ""}");
                        }
                    });
                });

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
