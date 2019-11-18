using DataTransformer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataTransformer.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = CoreConfigurationProvider.BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"), b => b.MigrationsAssembly("DataAggregator.Data"));
            return new ApplicationDbContext(builder.Options);
        }
    }
}
