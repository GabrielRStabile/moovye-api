using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Movye.Api.Utils;
using Movye.Identity.Configurations;

namespace Movye.Api.Extensions
{
    public static class AuthenticationSetup
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration _)
        {
            var serviceProvider = services.BuildServiceProvider();
            var env = serviceProvider.GetRequiredService<IOptions<AppEnvironments>>();

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(env.Value.JWT_SECRET)
            );

            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = env.Value.JWT_ISSUER;
                options.Audience = env.Value.JWT_AUDIENCE;
                options.SigningCredentials = new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha512
                );
                options.AccessTokenExpiration = int.Parse(env.Value.JWT_EXPIRATION ?? "0");
                options.RefreshTokenExpiration = int.Parse(env.Value.JWT_REFRESH_EXPIRATION ?? "0");
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = env.Value.JWT_ISSUER,
                ValidateAudience = true,
                ValidAudience = env.Value.JWT_AUDIENCE,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    options => options.TokenValidationParameters = tokenValidationParameters
                );
        }
    }
}
