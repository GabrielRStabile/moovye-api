using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Movye.Identity.Configurations;

namespace Movye.Api.Extensions
{
    public static class AuthenticationSetup
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Env.GetString("JWT_SECRET")));

            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = Env.GetString("JWT_ISSUER");
                options.Audience = Env.GetString("JWT_AUDIENCE");
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.AccessTokenExpiration = int.Parse(Env.GetString("JWT_EXPIRATION") ?? "0");
                options.RefreshTokenExpiration = int.Parse(Env.GetString("JWT_REFRESH_EXPIRATION") ?? "0");
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Env.GetString("JWT_ISSUER"),

                ValidateAudience = true,
                ValidAudience = Env.GetString("JWT_AUDIENCE"),

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
