using MechanicsBank.IdentityServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicsBank.IdentityServer.Data.Contexts
{
    public class IdentityServerLogContext: DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public IdentityServerLogContext(DbContextOptions<IdentityServerLogContext> options)
            : base(options)
        {
        }
    }
}
