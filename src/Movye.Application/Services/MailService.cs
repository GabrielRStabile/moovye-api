using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Movye.Domain.Interfaces.Services.IMailService;
using Movye.Domain.Interfaces.Services.IMailService.Requests;
using Movye.Api.Utils;

namespace Movye.Application.Services
{
    public class MailService : IMailService
    {
        private readonly AppEnvironments env;

        public MailService(IOptions<AppEnvironments> env)
        {
            this.env = env.Value;
        }

        public Task SendEmail(MailServiceSendEmailRequest request)
        {
            var client = new SmtpClient(env.SMTP_HOST, env.SMTP_PORT)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(env.SMTP_SENDER_EMAIL, env.SMTP_SENDER_PASSWORD)
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: $"{request.Sender.GetName()} <{env.SMTP_SENDER_EMAIL}>",
                    to: request.Email,
                    request.Subject,
                    request.Message
                )
            );
        }
    }
}
