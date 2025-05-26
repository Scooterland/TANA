using MimeKit;
using MailKit.Net.Smtp;
using TANA.Application.Interface;

namespace TANA.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSettingsService _emailSettingsService;
        private readonly string _smtpServer = "smtp.yourmailserver.com"; // SMTP-server adresse
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "your-email@example.com";
        private readonly string _smtpPassword = "your-email-password";

        public EmailService(IEmailSettingsService emailSettingsService)
        {
            _emailSettingsService = emailSettingsService;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, byte[] attachment)
        {
            var emailAddress = await _emailSettingsService.GetEmailAddressAsync();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Company", emailAddress));
            message.To.Add(new MailboxAddress("Recipient", toEmail));

            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = body,
            };

            if (attachment != null)
            {
                bodyBuilder.Attachments.Add("Rejseplan.pdf", attachment);
            }

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, false);
                await client.AuthenticateAsync(_smtpUsername, _smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
