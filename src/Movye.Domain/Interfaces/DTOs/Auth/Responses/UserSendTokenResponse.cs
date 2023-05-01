namespace Movye.Domain.Interfaces.DTOs.Auth.Responses
{
    public class UserSendTokenResponse : IResponse
    {
        public UserSendTokenResponse(List<string> errors)
        {
            Success = errors.Count == 0;
            Errors = errors;
        }
    }
}
