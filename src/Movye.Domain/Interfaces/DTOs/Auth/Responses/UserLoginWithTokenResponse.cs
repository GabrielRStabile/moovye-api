using System.Text.Json.Serialization;

namespace Movye.Domain.Interfaces.DTOs.Auth.Responses
{
    public class UserLoginWithTokenResponse : IResponse
    {
        public UserLoginWithTokenResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccessToken { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RefreshToken { get; private set; }
    }
}
