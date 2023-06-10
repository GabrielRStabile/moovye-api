using Microsoft.IdentityModel.Tokens;

namespace Movye.Identity.Configurations
{
    public class JwtOptions
    {
        public JwtOptions() { }

        public JwtOptions(
            string issuer,
            string audience,
            SigningCredentials signingCredentials,
            int accessTokenExpiration,
            int refreshTokenExpiration
        )
        {
            Issuer = issuer;
            Audience = audience;
            SigningCredentials = signingCredentials;
            AccessTokenExpiration = accessTokenExpiration;
            RefreshTokenExpiration = refreshTokenExpiration;
        }

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
