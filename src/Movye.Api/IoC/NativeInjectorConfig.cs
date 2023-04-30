using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movye.Data.Context;
using Movye.Domain.Entities;
using Movye.Identity.Data;
using Movye.Identity.Providers.PasswordlessLoginTokenProvider;

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
        }
    }
}
