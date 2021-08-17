using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCompany.BuildCore.EntityFrameworkCore
{
    public static class BuildCoreDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BuildCoreDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BuildCoreDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
