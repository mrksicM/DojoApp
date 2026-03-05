using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Repositories
{
    public class DojoDbContextFactory : IDesignTimeDbContextFactory<DojoDbContext>
    {
        public DojoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DojoDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=DojoAppDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new DojoDbContext(optionsBuilder.Options);
        }
    }
}