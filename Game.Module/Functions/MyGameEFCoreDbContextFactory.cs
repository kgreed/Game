using Game.Module.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Game.Module.Functions
{
    public class MyGameEFCoreDbContextFactory
    {
        public MyGameEFCoreDbContext MyCreateMyDbContext(string connectionString)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<MyGameEFCoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseChangeTrackingProxies();
            //optionsBuilder.UseObjectSpaceLinkProxies();
            return new MyGameEFCoreDbContext(optionsBuilder.Options);
        }

        public void TestAdd(string connectionString)
        {
            
                var dbContext = MyCreateMyDbContext(connectionString);

                var player = new Player
                {
                    Name = "Test Player " + Guid.NewGuid().ToString(),

                };
                dbContext.Players.Add(player);
                dbContext.SaveChanges();
                var count = dbContext.Players.Count();
                Debug.Print($"There are now {count} players");
            
            
        }
    }
}
