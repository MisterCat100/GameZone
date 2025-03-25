using Microsoft.EntityFrameworkCore;

namespace GameZone.Model;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) 
        : base(options)
    {}

    public DbSet<Player> Players { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Session> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasMany(p => p.Sessions)
            .WithOne()
            .HasForeignKey(s => s.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Player>()
            .HasOne<Subscription>()
            .WithOne()
            .HasForeignKey<Subscription>(s => s.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
