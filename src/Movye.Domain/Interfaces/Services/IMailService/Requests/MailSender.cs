namespace Movye.Domain.Interfaces.Services.IMailService.Requests
{
    public enum MailSender
    {
        AuthenticationService
    }

    public static class Extensions
    {
        public static string GetName(this MailSender sender)
        {
            return sender switch
            {
                MailSender.AuthenticationService => "Autenticador Movye",
                _ => "Movye App",
            };
        }
    }
}
