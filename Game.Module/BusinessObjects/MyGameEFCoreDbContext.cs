using DevExpress.ExpressApp.Design;
using Microsoft.EntityFrameworkCore;

namespace Game.Module.BusinessObjects
{
    [TypesInfoInitializer(typeof(MyGameContextInitializer))]
    public class MyGameEFCoreDbContext : DbContext
    {
        public MyGameEFCoreDbContext(DbContextOptions<GameEFCoreDbContext> options) : base(options)
        {
        }
        //public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        //public DbSet<MatchPlayer> MatchPlayers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
}
