using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string toEmail, string toName, string subject, string message, string html);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(string toEmail, string toName, string subject, string message, string html)
        {
            // setup
            var apiKey = _configuration[Constants.SendGridApiKey];
            var replyEmail = _configuration[Constants.ReplyEmail];
            var replyName = _configuration[Constants.ReplyName];

            // client instance
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(replyEmail, replyName);
            var to = new EmailAddress(toEmail, toName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, html);

            // response
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
    }
}