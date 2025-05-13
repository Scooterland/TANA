using System;
using System.Collections.Generic;

namespace TANA.Domain.Entities
{
    public class TemplateItem
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public bool IsSelected { get; set; } = true;
        public string Title { get; set; } = string.Empty;
        public string Activity { get; set; } = string.Empty;
        public string Meals { get; set; } = string.Empty;
        public string Accommodation { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

    public class TemplateModel
    {
        public int Id { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string ContactUrl { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string TemplateName { get; set; } = string.Empty;

        public string HeaderTitle { get; set; } = string.Empty;  // New
        public DateTime HeaderDate { get; set; } = DateTime.UtcNow; // New
        public string HeaderImageUrl { get; set; } = string.Empty;
        public string Layout { get; set; } = string.Empty;
        public string FontFamily { get; set; } = "Arial";
        public string PrimaryColor { get; set; } = "#f19d19";
        public string HeaderBgColor { get; set; } = "#f19d19";
        public string FooterBgColor { get; set; } = "#f19d19";

        public List<TemplateItem> Items { get; set; } = new List<TemplateItem>();

    }
}
