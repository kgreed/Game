using DevExpress.ExpressApp.EFCore.DesignTime;
using Microsoft.EntityFrameworkCore;

namespace Game.Module.BusinessObjects
{
    public class MyGameContextInitializer : DbContextTypesInfoInitializerBase
    {
        protected override DbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameEFCoreDbContext>()
                .UseSqlServer(";");
    

        return new MyGameEFCoreDbContext(optionsBuilder.Options);
        }
    }
}
