using Microsoft.EntityFrameworkCore;

namespace GRL.Persistence;

public class GrlDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.League> Leagues { get; set; }
    public DbSet<Models.Season> Seasons { get; set; }
    public DbSet<Models.Circuit> Circuits { get; set; }
    public DbSet<Models.Race> Races { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrlDbContext).Assembly);
    }
}