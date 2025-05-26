using TANA.Domain.Entities;
using System.Threading.Tasks;

namespace TANA.Application.Interface
{
    public interface ITemplateRepository
    {
        Task SaveTemplateAsync(TemplateEntity template);
        Task<List<TemplateEntity>> GetAllTemplatesAsync();
        Task<TemplateEntity?> GetTemplateByIdAsync(int id);
        Task DeleteTemplateAsync(int id);
        Task UpdateTemplateAsync(TemplateEntity template);


    }
}
