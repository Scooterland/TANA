using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Application.DTOs;
using QuestPDF.Fluent;

namespace TANA.Infrastructure.Services
{
    public class RejseplanDocument : IDocument
    {
        public RejseplanModel Model { get; }

        public RejseplanDocument(RejseplanModel model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("Rejseplan", TextStyle.Default.Size(24));
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(20).Text($"Navn: {Model.Navn}\nEmail: {Model.Email}\nDestination: {Model.Destination}\nAfrejse: {Model.Afrejse}\nHjemrejse: {Model.Hjemrejse}\nFlyselskab: {Model.Flyselskab}");
        }
    }
}
