namespace Movye.Domain.Interfaces.Services.IMailService.Requests
{

    public enum MailSender { AuthenticationService }
    public static class Extensions
    {
        public static string GetName(this MailSender sender)
        {
            switch (sender)
            {
                case MailSender.AuthenticationService:
                    return "Autenticador Movye";
                default:
                    return "Movye App";
            }
        }
    }
}
