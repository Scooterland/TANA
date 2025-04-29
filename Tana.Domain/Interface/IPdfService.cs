using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Domain.Interface
{
    public interface IPdfService
    {
        Task<byte[]> GeneratePdfAsync(string content);
    }
}
