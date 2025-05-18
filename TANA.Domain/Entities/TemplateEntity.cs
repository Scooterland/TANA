using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TemplateEntity
{
    public int Id { get; set; }

    [Required]
    public string TemplateName { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;  
    public string ImageUrl { get; set; } = string.Empty;  
    public string Layout { get; set; } = string.Empty;
    public string FontFamily { get; set; } = "Arial";
    public string PrimaryColor { get; set; } = "#f19d19";
    public string HeaderBgColor { get; set; } = "#f19d19";
    public string FooterBgColor { get; set; } = "#f19d19";
    public ICollection<TemplateItemEntity> Items { get; set; } = new List<TemplateItemEntity>();
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;

}

public class TemplateItemEntity
{
    public int Id { get; set; }

    [Required]
    public string Content { get; set; } = string.Empty;
    public int Order { get; set; }
    // Foreign Key
    public int TemplateEntityId { get; set; }

    [ForeignKey("TemplateEntityId")]
    public TemplateEntity Template { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string Activity { get; set; } = string.Empty;
    public string Meals { get; set; } = string.Empty;
    public string Accommodation { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}
