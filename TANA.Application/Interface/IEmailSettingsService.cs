using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANA.Application.Interface
{
    public interface IEmailSettingsService
    {
        Task<string> GetEmailAddressAsync();
        Task SetEmailAddressAsync(string emailAddress);
    }
}
