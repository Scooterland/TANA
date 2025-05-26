using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;
using TANA.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;

namespace TANA.Infrastructure.Services
{
    public class EmailSettingsService : IEmailSettingsService
    {
        private readonly AppDbContext _context;

        public EmailSettingsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetEmailAddressAsync()
        {
            var settings = await _context.EmailSettings.FirstOrDefaultAsync();
            return settings?.EmailAddress ?? string.Empty;
        }

        public async Task SetEmailAddressAsync(string emailAddress)
        {
            var settings = await _context.EmailSettings.FirstOrDefaultAsync();
            if (settings != null)
            {
                settings.EmailAddress = emailAddress;
                _context.EmailSettings.Update(settings);
            }
            else
            {
                settings = new EmailSettings { EmailAddress = emailAddress };
                await _context.EmailSettings.AddAsync(settings);
            }

            await _context.SaveChangesAsync();
        }
    }
}
