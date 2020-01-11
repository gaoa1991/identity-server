using MechanicsBank.IdentityServer.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MechanicsBank.IdentityServer.Data.Contexts
{
    public class IdentityServerContext : IdentityDbContext<User, Role, string>
    {
        public IdentityServerContext(DbContextOptions<IdentityServerContext> options) : base(options)
        {

        }
    }
}
