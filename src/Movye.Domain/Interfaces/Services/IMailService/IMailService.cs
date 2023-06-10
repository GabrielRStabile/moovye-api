using Movye.Domain.Interfaces.Services.IMailService.Requests;

namespace Movye.Domain.Interfaces.Services.IMailService
{
    public interface IMailService
    {
        Task SendEmail(MailServiceSendEmailRequest request);
    }
}
