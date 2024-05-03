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
            
            var optionsBuilder = new DbContextOptionsBuilder<GameEFCoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseChangeTrackingProxies();
            //optionsBuilder.UseObjectSpaceLinkProxies();
            return new MyGameEFCoreDbContext(optionsBuilder.Options);
        }

        public void TestAdd(string connectionString)
        {
            try
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
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());

            }
            
        }
    }
}
