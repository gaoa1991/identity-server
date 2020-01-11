using AutoMapper;
using MechanicsBank.IdentityServer.Domain.Mappers.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MechanicsBank.IdentityServer.Domain.Extensions
{
    public static class IdentityExtensions
    {
        public static IMapperConfigurationBuilder AddAdminAspNetIdentityMapping(this IServiceCollection services)
        {
            var builder = new MapperConfigurationBuilder();

            services.AddSingleton<IConfigurationProvider>(sp => new MapperConfiguration(cfg =>
            {
                foreach (var profileType in builder.ProfileTypes)
                    cfg.AddProfile(profileType);
            }));

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            return builder;
        }

        public static IServiceCollection AddMappingProfiles(this IServiceCollection services, HashSet<Type> profileTypes)
        {
            services.AddAdminAspNetIdentityMapping()
                .UseIdentityMappingProfile()
                .AddProfilesType(profileTypes);

            return services;
        }
    }
}
