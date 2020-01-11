using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicsBank.IdentityServer.Domain.Mappers.Configuration
{
    public interface IMapperConfigurationBuilder
    {
        HashSet<Type> ProfileTypes { get; }

        IMapperConfigurationBuilder AddProfilesType(HashSet<Type> profileTypes);

        IMapperConfigurationBuilder UseIdentityMappingProfile();
    }

    public class MapperConfigurationBuilder : IMapperConfigurationBuilder
    {
        public HashSet<Type> ProfileTypes { get; } = new HashSet<Type>();

        public IMapperConfigurationBuilder AddProfilesType(HashSet<Type> profileTypes)
        {
            if (profileTypes == null) return this;

            foreach (var profileType in profileTypes)
            {
                ProfileTypes.Add(profileType);
            }

            return this;
        }

        public IMapperConfigurationBuilder UseIdentityMappingProfile()
        {
            ProfileTypes.Add(typeof(IdentityMapperProfile));
            return this;
        }
    }
}
