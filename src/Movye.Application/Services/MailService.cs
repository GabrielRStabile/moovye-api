using System.Net;
using System.Net.Mail;
using DotNetEnv;
using Movye.Domain.Interfaces.Services.IMailService;
using Movye.Domain.Interfaces.Services.IMailService.Requests;

namespace Movye.Application.Services
{
    public class MailService : IMailService
    {
        public Task SendEmail(MailServiceSendEmailRequest request)
        {
            var client = new SmtpClient(Env.GetString("STMP_HOST"), Env.GetInt("STMP_PORT"))
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Env.GetString("SMTP_SENDER_EMAIL"), Env.GetString("SMTP_SENDER_PASSWORD"))
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: $"{request.Sender.GetName()} <{Env.GetString("SMTP_SENDER_EMAIL")}>",
                    to: request.Email, request.Subject, request.Message
                )
            );
        }
    }
}
