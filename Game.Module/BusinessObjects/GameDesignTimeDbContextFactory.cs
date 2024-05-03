using Microsoft.EntityFrameworkCore.Design;

namespace Game.Module.BusinessObjects
{
    //This factory creates DbContext for design-time services. For example, it is required for database migration.
    public class GameDesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameEFCoreDbContext>
    {
        public GameEFCoreDbContext CreateDbContext(string[] args)
        {
            throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
            //var optionsBuilder = new DbContextOptionsBuilder<GameEFCoreDbContext>();
            //optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Game");
            //optionsBuilder.UseChangeTrackingProxies();
            //optionsBuilder.UseObjectSpaceLinkProxies();
            //return new GameEFCoreDbContext(optionsBuilder.Options);
        }
    }
}
