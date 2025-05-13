using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TANA.Infrastructure.Services
{
    public class TemplateLibraryService
    {
        private readonly string _templatePath;

        public TemplateLibraryService()
        {
            _templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "TemplateLibrary");

            if (!Directory.Exists(_templatePath))
            {
                Directory.CreateDirectory(_templatePath);
                Console.WriteLine($"Created directory: {_templatePath}");
            }
        }

        public List<string> GetTemplateFiles()
        {
            try
            {
                Console.WriteLine($"Loading templates from: {_templatePath}");
                var files = Directory.GetFiles(_templatePath, "*.pdf", SearchOption.AllDirectories);
                return files.Select(Path.GetFileName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading templates: {ex.Message}");
                return new List<string>();
            }
        }


        public byte[]? GetTemplateFile(string fileName)
        {
            try
            {
                var files = Directory.GetFiles(_templatePath, "*.pdf", SearchOption.AllDirectories);

                var filePath = files.FirstOrDefault(f => Path.GetFileName(f) == fileName);

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    Console.WriteLine($"File found: {filePath}");
                    return File.ReadAllBytes(filePath);
                }

                Console.WriteLine($"File not found: {fileName}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing file: {ex.Message}");
                return null;
            }
        }


        public async Task<string> SaveTemplateFileAsync(Stream fileStream, string templateName, string fileName)
        {
            var templateDirectory = Path.Combine(_templatePath, templateName);

            if (!Directory.Exists(templateDirectory))
            {
                Directory.CreateDirectory(templateDirectory);
            }

            var filePath = Path.Combine(templateDirectory, fileName);

            try
            {
                using var fileStreamOutput = new FileStream(filePath, FileMode.Create);
                await fileStream.CopyToAsync(fileStreamOutput);
                Console.WriteLine($"File saved at: {filePath}");
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                throw;
            }
        }





    }
}
