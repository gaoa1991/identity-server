using IdentityServer4.EntityFramework.Storage;
using MechanicsBank.IdentityServer.Data.Contexts;
using MechanicsBank.IdentityServer.Data.Entities.Identity;
using MechanicsBank.IdentityServer.Data.Repositories;
using MechanicsBank.IdentityServer.Data.Repositories.Interfaces;
using MechanicsBank.IdentityServer.Domain.Services;
using MechanicsBank.IdentityServer.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IdentityAdmin.Helpers
{
    public static class StartupHelpers
    {
        public static void AddDbContexts(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            // Config DB for identity
            services.AddDbContext<IdentityServerContext>(options =>
                options.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly)));

            // Config DB from existing connection
            services.AddConfigurationDbContext<IdentityServerConfigurationDbContext>(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
            });

            // Operational DB from existing connection
            services.AddOperationalDbContext<IdentityServerPersistedGrantDbContext>(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
            });

            // Log DB from existing connection
            services.AddDbContext<IdentityServerLogContext>(options =>
                options.UseSqlServer(connectionString,
                    optionsSql => optionsSql.MigrationsAssembly(migrationsAssembly)));
        }

        public static void AddAuthenticationServices(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<IdentityServerContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            //Adding Database repositories
            services.AddScoped<IIdentityRepository, IdentityRepository>();

            //Adding main services
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
