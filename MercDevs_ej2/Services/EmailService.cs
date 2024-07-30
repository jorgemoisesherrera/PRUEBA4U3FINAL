using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MercDevs_ej2.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpClient _client;

        public EmailService()
        {
            _client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("jorge.herrera.alderete@cftmail.com", "0000"),
                EnableSsl = true,
            };
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("jorge.herrera.alderete@cftmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);

            await _client.SendMailAsync(mailMessage);
        }
    }
}

