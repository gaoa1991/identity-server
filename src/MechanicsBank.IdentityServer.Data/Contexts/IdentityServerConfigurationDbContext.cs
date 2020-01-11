using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace MechanicsBank.IdentityServer.Data.Contexts
{
    public class IdentityServerConfigurationDbContext: ConfigurationDbContext<IdentityServerConfigurationDbContext>
    {
        public IdentityServerConfigurationDbContext(DbContextOptions<IdentityServerConfigurationDbContext> options, ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }
}
