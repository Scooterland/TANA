using TANA.Domain.Entities;

namespace TANA.Application.Services
{
    public class TemplateStateService
    {
        public TemplateModel CurrentTemplate { get; private set; } = new TemplateModel
        {
            Items = new List<TemplateItem>
            {
                new() { Id = "1", Content = "Header", Order = 1 },
                new() { Id = "2", Content = "Image", Order = 2 },
                new() { Id = "3", Content = "Summary", Order = 3 },
                new() { Id = "4", Content = "Day Sections", Order = 4 }
            }
        };

        public void SetTemplate(TemplateModel newTemplate)
        {
            CurrentTemplate = newTemplate;
        }
    }
}
