using Microsoft.EntityFrameworkCore;
using TANA.Domain.Entities;
using TANA.Domain.Interface;
using TANA.Persistence.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TANA.Persistence.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly AppDbContext _context;

        public TemplateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveTemplateAsync(TemplateEntity template)
        {
            if (template.Id == 0)
            {
                template.CreatedDate = DateTime.UtcNow;
                template.LastModifiedDate = DateTime.UtcNow;
                _context.Templates.Add(template);
            }
            else
            {
                await UpdateTemplateAsync(template);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTemplateAsync(TemplateEntity template)
        {
            var existingTemplate = await _context.Templates
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

                // تحديث Day Sections
                _context.TemplateItems.RemoveRange(existingTemplate.Items);

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

                _context.Templates.Update(existingTemplate);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<List<TemplateEntity>> GetAllTemplatesAsync()
        {
            return await _context.Templates.Include(t => t.Items).ToListAsync();
        }

        public async Task<TemplateEntity?> GetTemplateByIdAsync(int id)
        {
            return await _context.Templates.Include(t => t.Items).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task DeleteTemplateAsync(int id)
        {
            var template = await _context.Templates.Include(t => t.Items).FirstOrDefaultAsync(t => t.Id == id);
            if (template != null)
            {
                // 1. حذف العناصر المرتبطة من قاعدة البيانات
                _context.TemplateItems.RemoveRange(template.Items);
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync();

                // 2. حذف الملفات المرتبطة
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
