using TANA.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;


namespace TANA.Persistence.Repositories
{
    public class TemplateRepository : ITemplateRepository
	{
        private readonly AppDbContext db;

        public TemplateRepository(AppDbContext context) => db = context;

        public async Task SaveTemplateAsync(TemplateEntity template)
        {
            if (template.Id == 0)
            {
                template.CreatedDate = DateTime.UtcNow;
                template.LastModifiedDate = DateTime.UtcNow;
                db.Templates.Add(template);
            }
            else
            {
                await UpdateTemplateAsync(template);
            }

            await db.SaveChangesAsync();
        }

        public async Task UpdateTemplateAsync(TemplateEntity template)
        {
            var existingTemplate = await db.Templates
                                                 .Include(t => t.Items)
                                                 .FirstOrDefaultAsync(t => t.Id == template.Id);

            if (existingTemplate != null)
            {
                existingTemplate.TemplateName = template.TemplateName;
                existingTemplate.Summary = template.Summary;
                existingTemplate.ImageUrl = template.ImageUrl;
                existingTemplate.LastModifiedDate = DateTime.UtcNow;
                existingTemplate.Layout = template.Layout;
                existingTemplate.FontFamily = template.FontFamily;
                existingTemplate.PrimaryColor = template.PrimaryColor;
                existingTemplate.HeaderBgColor = template.HeaderBgColor;
                existingTemplate.FooterBgColor = template.FooterBgColor;

                db.TemplateItems.RemoveRange(existingTemplate.Items);

                foreach (var item in template.Items)
                {
                    existingTemplate.Items.Add(new TemplateItemEntity
                    {
                        Content = item.Content,
                        Title = item.Title,
                        Activity = item.Activity,
                        Meals = item.Meals,
                        Accommodation = item.Accommodation,
                        Note = item.Note,
                        Order = item.Order,
                        TemplateEntityId = template.Id
                    });
                }

                db.Templates.Update(existingTemplate);
            }

            await db.SaveChangesAsync();
        }


        public async Task<List<TemplateEntity>> GetAllTemplatesAsync()
        {
            return await db.Templates.Include(t => t.Items).ToListAsync();
        }

        public async Task<TemplateEntity?> GetTemplateByIdAsync(int id)
        {
            return await db.Templates.Include(t => t.Items).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task DeleteTemplateAsync(int id)
        {
            var template = await db.Templates.Include(t => t.Items).FirstOrDefaultAsync(t => t.Id == id);
            if (template != null)
            {
				db.TemplateItems.RemoveRange(template.Items);
				db.Templates.Remove(template);
                await db.SaveChangesAsync();

                DeleteTemplateFile(template.TemplateName);
            }
        }

        private void DeleteTemplateFile(string templateName)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "TemplateLibrary", templateName);

            if (Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.Delete(directoryPath, true);
                    Console.WriteLine($"Directory deleted: {directoryPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting directory: {ex.Message}");
                }
            }
        }
    }
}
