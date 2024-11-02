using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class League : IEntityTypeConfiguration<League>
{
    [Key]
    [Description("Primary key for the League entity.")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Description("Name of the league.")]
    public string Name { get; set; } = null!;

    // Navigation property to Seasons
    [Description("Collection of seasons associated with the league.")]
    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();

    // Navigation property to Teams
    [Description("Collection of teams in the league.")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasKey(l => l.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(l => l.Seasons)
            .WithOne(s => s.League)
            .HasForeignKey(s => s.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(l => l.Teams)
            .WithOne(t => t.League)
            .HasForeignKey(t => t.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}