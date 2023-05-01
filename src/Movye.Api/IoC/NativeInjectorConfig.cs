using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movye.Application.Services;
using Movye.Data.Context;
using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IIdentityService;
using Movye.Domain.Interfaces.Services.IJwtService;
using Movye.Domain.Interfaces.Services.IMailService;
using Movye.Identity.Data;
using Movye.Identity.Providers.PasswordlessLoginTokenProvider;
using Movye.Identity.Services;

namespace Movye.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Env.GetString("POSTGRE_DB_CONNECTION_STRING"))
            );

            services.AddDbContext<IdentityDataContext>(options =>
                options.UseNpgsql(Env.GetString("POSTGRE_DB_CONNECTION_STRING"))
            );

            services.AddDefaultIdentity<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders()
                .AddPasswordlessLoginTotpTokenProvider();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            });

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddTransient<IMailService, MailService>();
        }
    }
}
