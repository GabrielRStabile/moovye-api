using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Movye.Api.Utils;
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
        public static void RegisterServices(this IServiceCollection services, IConfiguration _)
        {
            var serviceProvider = services.BuildServiceProvider();
            var env = serviceProvider.GetRequiredService<IOptions<AppEnvironments>>();

            services.AddDbContext<DataContext>(
                options => options.UseNpgsql(env.Value.POSTGRE_DB_CONNECTION_STRING)
            );

            services.AddDbContext<IdentityDataContext>(
                options => options.UseNpgsql(env.Value.POSTGRE_DB_CONNECTION_STRING)
            );

            services
                .AddDefaultIdentity<User>()
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
