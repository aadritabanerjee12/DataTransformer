using DataTransformer.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DataTransformer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LoadProfile> LoadProfiles { get; set; }
        public DbSet<ToU> ToUs { get; set; }


    }
}
