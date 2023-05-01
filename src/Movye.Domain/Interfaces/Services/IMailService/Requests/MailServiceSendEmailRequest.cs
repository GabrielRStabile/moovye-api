namespace Movye.Domain.Interfaces.Services.IMailService.Requests
{
    public class MailServiceSendEmailRequest
    {
        public MailServiceSendEmailRequest(string email, string subject, string message, MailSender sender)
        {
            Email = email;
            Subject = subject;
            Message = message;
            Sender = sender;
        }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public MailSender Sender { get; set; }
    }
}
