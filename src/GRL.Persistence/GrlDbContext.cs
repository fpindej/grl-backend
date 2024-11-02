using GRL.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GRL.Persistence;

internal class GrlDbContext : DbContext
{
    public DbSet<League> Leagues { get; set; } = null!;
    public DbSet<Season> Seasons { get; set; } = null!;
    public DbSet<Circuit> Circuits { get; set; } = null!;
    public DbSet<Race> Races { get; set; } = null!;
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<RaceResult> RaceResults { get; set; } = null!;
    public DbSet<Penalty> Penalties { get; set; } = null!;
    public DbSet<DriverTeamAssignment> DriverTeamAssignments { get; set; } = null!;

    public GrlDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrlDbContext).Assembly);

        modelBuilder.SeedData();
    }
}