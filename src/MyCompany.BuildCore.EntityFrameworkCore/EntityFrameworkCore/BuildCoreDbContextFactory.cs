using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCompany.BuildCore.Configuration;
using MyCompany.BuildCore.Web;

namespace MyCompany.BuildCore.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BuildCoreDbContextFactory : IDesignTimeDbContextFactory<BuildCoreDbContext>
    {
        public BuildCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BuildCoreDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BuildCoreDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BuildCoreConsts.ConnectionStringName));

            return new BuildCoreDbContext(builder.Options);
        }
    }
}
