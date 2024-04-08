using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace Game.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class GameContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<GameEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new GameEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class GameDesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameEFCoreDbContext> {
	public GameEFCoreDbContext CreateDbContext(string[] args) {
		throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		//var optionsBuilder = new DbContextOptionsBuilder<GameEFCoreDbContext>();
		//optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Game");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
		//return new GameEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(GameContextInitializer))]
public class GameEFCoreDbContext : DbContext {
	public GameEFCoreDbContext(DbContextOptions<GameEFCoreDbContext> options) : base(options) {
	}
	//public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<Match> Matches { get; set; }
	public DbSet<Player> Players { get; set; }
	//public DbSet<MatchPlayer> MatchPlayers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

		// In MatchPlayer the combination of Match and Player should be unique
	 	//modelBuilder.Entity<MatchPlayer>().HasIndex(mp => new { mp.Match, mp.Player }).IsUnique();
		// set up relationship between player and preferredplayer1 one or none
		// allow none
		modelBuilder.Entity<Player>().HasOne(p => p.PreferredPlayer1).WithOne().HasForeignKey<Player>(p => p.PreferredPlayer1Guid);
    }
}
