using Microsoft.EntityFrameworkCore;
using MultiTenantArchitecture.Data.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantArchitecture.Data.Contexts
{
    public class TenantDbContext: DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { 
        
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
