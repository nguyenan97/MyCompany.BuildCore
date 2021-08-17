using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCompany.BuildCore.Authorization.Roles;
using MyCompany.BuildCore.Authorization.Users;
using MyCompany.BuildCore.MultiTenancy;

namespace MyCompany.BuildCore.EntityFrameworkCore
{
    public class BuildCoreDbContext : AbpZeroDbContext<Tenant, Role, User, BuildCoreDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BuildCoreDbContext(DbContextOptions<BuildCoreDbContext> options)
            : base(options)
        {
        }
    }
}
